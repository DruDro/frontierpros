using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Questions;
using FrontierPros.Core.Domain.Specialties;
using FrontierPros.Services.Catalog;
using FrontierPros.Services.ServiceCategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Data;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Security;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Services;

namespace Nop.Web.Areas.Admin.Controllers.Api
{
    [Route("api/[area]/[controller]")]
    [ApiController]
	[Area(AreaNames.Admin)]
	//[HttpsRequirement(SslRequirement.Yes)]
	//[AuthorizeAdmin]
	public class ServicesController : BaseController
	{
		private readonly IRepository<Question> _questionRepository;
		private readonly IRepository<Option> _optionRepository;
		private readonly IRepository<Specialty> _specialtyRepository;
		private readonly IRepository<ServiceInfoAndNameToken> _serviceInfoNameTokenRepository;
		private readonly IRepository<ServiceCategoryAndServiceInfo> _serviceCategoryAndServiceInfoRepository;
		private readonly IServiceInfoService _serviceInfoService;
		private readonly IServiceCategoryService _serviceCategoryService;

		public ServicesController(IRepository<Question> questionRepository,
									IRepository<Option> clientOptionRepository,
									IRepository<Specialty> specialtyRepository,
									IRepository<ServiceInfoAndNameToken> serviceInfoNameTokenRepository,
									IRepository<ServiceCategoryAndServiceInfo> serviceCategoryAndServiceInfoRepository,
									IServiceInfoService serviceInfoService,
									IServiceCategoryService serviceCategoryService)
		{
			this._questionRepository = questionRepository;
			this._optionRepository = clientOptionRepository;
			this._specialtyRepository = specialtyRepository;
			this._serviceInfoNameTokenRepository = serviceInfoNameTokenRepository;
			this._serviceCategoryAndServiceInfoRepository = serviceCategoryAndServiceInfoRepository;
			this._serviceInfoService = serviceInfoService;
			this._serviceCategoryService = serviceCategoryService;
		}

		#region ServiceInfo

		[HttpGet("{id?}")]
		public IActionResult Index(int id)
		{
			var serviceInfo = _serviceInfoService.GetServiceInfoById(id, includeCategories:true);

			if (serviceInfo == null)
			{
				return new JsonResult(null);
			}

			var serviceInfoDto = new
			{
				serviceInfo.Id,
				serviceInfo.Name,
				serviceInfo.Published,
				serviceInfo.Deleted,
				ServiceCategories = serviceInfo.ServiceCategories.Select(s => new {
					s.ServiceCategory.Id,
					s.ServiceCategory.Name
				}).ToArray()
			};

			return new JsonResult(serviceInfoDto);
		}

		[HttpPost]
		public IActionResult Index(ServiceInfoFilterModel filter)
		{
			var serviceInfoEntities = _serviceInfoService.GetAllServiceInfoEntities(filter.Name, filter.PageIndex, filter.PageSize, filter.IncludeCategories, showHidden:true);
			if (filter.IncludeCategories)
			{
				var serviceInfoWithCategoriesDtos = serviceInfoEntities.Select(c => new {
					c.Id,
					c.Name,
					c.Published,
					c.Deleted,
					ServiceCategories = c.ServiceCategories.Select(sc => new {
						sc.ServiceCategory.Id,
						sc.ServiceCategory.Name
					}).ToArray()
				}).ToArray();

				return new JsonResult(serviceInfoWithCategoriesDtos);
			}

			var serviceInfoDtos = serviceInfoEntities.Select(c => new {
				c.Id,
				c.Name,
				c.Published,
				c.Deleted
			}).ToArray();

			return new JsonResult(serviceInfoDtos);
		}

		[HttpPost("add")]
		public IActionResult Add(CreateServiceInfoModel model)
		{
			var success = false;
			var message = string.Empty;
			var id = -1;

			try
			{
				var serviceInfo = _serviceInfoService.GetServiceInfoByName(model.Name);
				if (serviceInfo == null)
				{
					var serviceInfoToAdd = new ServiceInfo()
					{
						Name = model.Name,
						CreatedOnUtc = DateTime.UtcNow,
						UpdatedOnUtc = DateTime.UtcNow,
					};
					_serviceInfoService.InsertServiceInfo(serviceInfoToAdd);
					id = serviceInfoToAdd.Id;

					var serviceCategoryMappings = new List<ServiceCategoryAndServiceInfo>();
					foreach (var serviceCategoryId in model.ServiceCategoryIds)
					{
						if (_serviceCategoryService.GetServiceCategoryById(serviceCategoryId) != null)
						{
							var mapping = new ServiceCategoryAndServiceInfo()
							{
								ServiceCategoryId = serviceCategoryId,
								ServiceInfoId = id
							};
							serviceCategoryMappings.Add(mapping);

						}
					}
					_serviceCategoryAndServiceInfoRepository.Insert(serviceCategoryMappings);

					success = true;
				}
				else
				{
					message = "Service already exists";
				}

			}
			catch
			{

			}

			return new JsonResult(new { id, success, message });
		}

		[HttpPost("edit")]
		public IActionResult Edit(EditServiceInfoModel model)
		{
			var success = false;
			var message = string.Empty;

			try
			{
				var serviceInfoByName = _serviceInfoService.GetServiceInfoByName(model.Name);
				if (serviceInfoByName == null || serviceInfoByName.Id == model.Id)
				{
					var serviceInfoToUpdate = _serviceInfoService.GetServiceInfoById(model.Id);
					if (serviceInfoToUpdate != null && serviceInfoToUpdate.Id == model.Id)
					{

						if (serviceInfoToUpdate.Name != model.Name)
						{
							serviceInfoToUpdate.Name = model.Name;
							serviceInfoToUpdate.UpdatedOnUtc = DateTime.UtcNow;

							_serviceInfoService.UpdateServiceInfo(serviceInfoToUpdate);
						}

						if (model.ServiceCategoryIds.Count() > 0)
						{
							var existingServiceCategoryMappings = _serviceCategoryAndServiceInfoRepository.Table.Where(si => si.ServiceInfoId == serviceInfoToUpdate.Id).ToList();

							var serviceCategoryMappingsToDelete = existingServiceCategoryMappings.Where(s => !model.ServiceCategoryIds.Contains(s.ServiceCategoryId)).ToArray();
							var serviceCategoryMappingIdsToAdd = model.ServiceCategoryIds.Where(id => !existingServiceCategoryMappings.Any(s => s.ServiceCategoryId == id)).ToArray();
							var serviceCategoryMappingsToAdd = new List<ServiceCategoryAndServiceInfo>();

							foreach (var serviceCategoryId in serviceCategoryMappingIdsToAdd)
							{
								if (_serviceCategoryService.GetServiceCategoryById(serviceCategoryId) != null)
								{
									var mapping = new ServiceCategoryAndServiceInfo()
									{
										ServiceCategoryId = serviceCategoryId,
										ServiceInfoId = serviceInfoToUpdate.Id
									};
									serviceCategoryMappingsToAdd.Add(mapping);
								}
							}

							_serviceCategoryAndServiceInfoRepository.Insert(serviceCategoryMappingsToAdd);
							_serviceCategoryAndServiceInfoRepository.Delete(serviceCategoryMappingsToDelete);
						}
						success = true;
					}
				}
				else
				{
					message = "Service already exists";
				}
			}
			catch
			{

			}
			return new JsonResult(new { success, message });
		}

		[HttpPost("delete/{id?}")]
		public IActionResult Delete(int id)
		{
			var success = false;
			var message = string.Empty;

			try
			{
				var serviceInfoToDelete = _serviceInfoService.GetServiceInfoById(id);
				if (serviceInfoToDelete != null)
				{
					_serviceInfoService.DeleteServiceInfo(serviceInfoToDelete);
					success = true;
				}
			}
			catch
			{

			}

			return new JsonResult(new { success, message });
		}
		#endregion

		#region Questionnaires
		[HttpGet("{serviceInfoId}/questionnaire")]
		public IActionResult GetQuestionnaireByServiceInfoId(int serviceInfoId)
		{
			var questions = _questionRepository.TableNoTracking.Include(q => q.Options)
				.Where(q => q.ServiceInfoId == serviceInfoId)
				.OrderByDescending(q => q.IsStartQuestion)
				.OrderBy(q => q.Order)
				.Select(q => new {
					q.Id,
					q.ProviderHeading,
					q.ProviderSubHeading,
					q.Heading,
					q.SubHeading,
					q.Placeholder,
					Type = q.Type.ToString(),
					q.NextQuestionId,
					q.IsRequired,
					q.IsStartQuestion,
					q.IsProviderQuestion,
					q.IsPaidQuestion,
					q.Order,
					Options = q.Options.OrderBy(o => o.Order).Select(o => new {
						o.Id,
						o.ProviderText,
						o.Text,
						o.Order,
						o.NextQuestionId
					})
					.ToArray(),
				})
				.ToArray();

			return new JsonResult(questions);
		}

		[HttpPost("{serviceInfoId}/questionnaire/add")]
		public IActionResult AddQuestionnaire(int serviceInfoId, QuestionnaireModel model)
		{
			var success = false;
			var message = string.Empty;

			if (!_serviceInfoService.IsExistServiceInfo(serviceInfoId))
			{
				return new JsonResult(new { success = false, message = "Service not found" });
			}
			if (!IsValidQuestionnaireModel(model))
			{
				return new JsonResult(new { success = false, message = "Questionnaire is invalid" });
			}

			if (_questionRepository.TableNoTracking.Any(q => q.ServiceInfoId == serviceInfoId))
			{
				return new JsonResult(new { success = false, message = "Questionnaire already exists" });
			}

			try
			{
				var questionMappingDict = new Dictionary<int, Question>();
				var optionMappingDict = new Dictionary<int, Option>();
					
				//saving questions and options
				foreach (var question in model.Questions)
				{
					var questionToAdd = new Question()
					{
						ServiceInfoId = serviceInfoId,
						ProviderHeading = question.ProviderHeading,
						ProviderSubHeading = question.ProviderSubHeading,
						IsProviderQuestion = question.IsProviderQuestion,
						IsPaidQuestion = question.IsProviderQuestion,
						Order = question.Order,
						Heading = question.Heading,
						SubHeading = question.SubHeading,
						Placeholder = question.Placeholder,
						Type = question.Type,
						IsStartQuestion = question.IsStartQuestion,
						IsRequired = question.IsRequired
					};
					_questionRepository.Insert(questionToAdd);

					foreach (var option in question.Options)
					{
						var optionToAdd = new Option()
						{
							ProviderText = option.ProviderText,
							Text = option.Text,
							Placeholder = option.Placeholder,
							Order = option.Order,
							QuestionId = questionToAdd.Id
						};
						_optionRepository.Insert(optionToAdd);
						optionMappingDict.Add(option.Id, optionToAdd);
					}

					questionMappingDict.Add(question.Id, questionToAdd);
				}

				//linking questions and options
				foreach(var question in model.Questions)
				{
					if (question.NextQuestionId.HasValue && question.NextQuestionId < 0)
					{
						var addedQuestion = questionMappingDict[question.Id];
						var nextQuestion = questionMappingDict[question.NextQuestionId.Value];

						addedQuestion.NextQuestionId = nextQuestion.Id;
						_questionRepository.Update(addedQuestion);
					}

					foreach(var option in question.Options)
					{
						if (option.NextQuestionId.HasValue && option.NextQuestionId.Value < 0)
						{
							var addedOption = optionMappingDict[option.Id];
							var nextQuestion = questionMappingDict[option.NextQuestionId.Value];
							addedOption.NextQuestionId = nextQuestion.Id;
							_optionRepository.Update(addedOption);
						}
					}
				}

				success = true;
			}
			catch
			{

			}
			return new JsonResult(new { success, message });
		}

		[HttpPost("{serviceInfoId}/questionnaire/edit")]
		public IActionResult EditQuestionnaire(int serviceInfoId, QuestionnaireModel model)
		{
			var success = false;
			var message = string.Empty;

			if (!_serviceInfoService.IsExistServiceInfo(serviceInfoId))
			{
				return new JsonResult(new { success = false, message = "Service not found" });
			}
			if (!IsValidQuestionnaireModel(model))
			{
				return new JsonResult(new { success = false, message = "Questionnaire is invalid" });
			}
			if (!_questionRepository.TableNoTracking.Any(q => q.ServiceInfoId == serviceInfoId))
			{
				message = "Questionnaire does not exist";
			}

			try
			{
				var currentQuestions = _questionRepository.Table.Include(q => q.Options)
						.Where(q => q.ServiceInfoId == serviceInfoId)
						.ToArray();
				var currentOptions = currentQuestions.SelectMany(q => q.Options).ToArray();

				var updatedQuestionIds = model.Questions.Select(q => q.Id).Where(id => id > 0).ToArray();
				var updatedOptionIds = model.Questions.SelectMany(q=>q.Options).Select(o => o.Id).Where(id => id > 0).ToArray();

				//deleting questions after update
				var questionsToDelete = currentQuestions.Where(q => !updatedQuestionIds.Contains(q.Id)).ToArray();
				_questionRepository.Delete(questionsToDelete);
				
				//deleting options after update
				var optionsToDelete = currentOptions.Where(o => !updatedOptionIds.Contains(o.Id)).ToArray();
				_optionRepository.Delete(optionsToDelete);

				var questionsToAdd = model.Questions.Where(q => q.Id < 0).ToArray();
				var questionsToUpdate = model.Questions.Where(q => q.Id > 0).ToArray();

				var questionMappingDict = new Dictionary<int, Question>();
				var optionMappingDict = new Dictionary<int, Option>();

				
				foreach (var question in questionsToAdd)
				{
					//adding new questions
					var questionToAdd = new Question()
					{
						ServiceInfoId = serviceInfoId,
						ProviderHeading = question.ProviderHeading,
						ProviderSubHeading = question.ProviderSubHeading,
						IsProviderQuestion = question.IsProviderQuestion,
						IsPaidQuestion = question.IsPaidQuestion,
						Order = question.Order,
						Heading = question.Heading,
						SubHeading = question.SubHeading,
						Placeholder = question.Placeholder,
						Type = question.Type,
						IsStartQuestion = question.IsStartQuestion,
						IsRequired = question.IsRequired
					};
					_questionRepository.Insert(questionToAdd);

					//adding new options for added question
					foreach (var option in question.Options)
					{
						var optionToAdd = new Option()
						{
							ProviderText = option.ProviderText,
							Text = option.Text,
							Placeholder = option.Placeholder,
							Order = option.Order,
							QuestionId = questionToAdd.Id
						};
						_optionRepository.Insert(optionToAdd);
						optionMappingDict.Add(option.Id, optionToAdd);
					}

					questionMappingDict.Add(question.Id, questionToAdd);
				}

				foreach (var question in questionsToUpdate)
				{
					//updating question data
					var updatedQuestion = currentQuestions.FirstOrDefault(q => q.Id == question.Id);
					if(updatedQuestion != null)
					{
						updatedQuestion.ProviderHeading = question.ProviderHeading;
						updatedQuestion.ProviderSubHeading = question.ProviderSubHeading;
						updatedQuestion.IsProviderQuestion = question.IsProviderQuestion;
						updatedQuestion.IsPaidQuestion = question.IsPaidQuestion;
						updatedQuestion.Order = question.Order;
						updatedQuestion.Heading = question.Heading;
						updatedQuestion.SubHeading = question.SubHeading;
						updatedQuestion.Placeholder = question.Placeholder;
						updatedQuestion.Type = question.Type;
						updatedQuestion.IsStartQuestion = question.IsStartQuestion;
						updatedQuestion.IsRequired = question.IsRequired;
						_questionRepository.Update(updatedQuestion);

						//adding new options for question
						var newOptionsToAdd = question.Options.Where(o => o.Id < 0).ToArray();
						foreach (var option in newOptionsToAdd)
						{
							var optionToAdd = new Option()
							{
								ProviderText = option.ProviderText,
								Text = option.Text,
								Placeholder = option.Placeholder,
								Order = option.Order,
								QuestionId = updatedQuestion.Id
							};
							_optionRepository.Insert(optionToAdd);
							optionMappingDict.Add(option.Id, optionToAdd);
						}

						//updating existing options for question
						var optionsToUpdate = question.Options.Where(o => o.Id > 0).ToArray();
						foreach(var option in optionsToUpdate)
						{
							var updatedOption = currentOptions.FirstOrDefault(o => o.Id == option.Id);
							if(updatedOption != null)
							{
								updatedOption.ProviderText = option.ProviderText;
								updatedOption.Text = option.Text;
								updatedOption.Placeholder = option.Placeholder;
								updatedOption.Order = option.Order;
								_optionRepository.Update(updatedOption);
							}
						}
					}
				}

				//linking questions and options
				foreach (var question in model.Questions)
				{
					var questionToLink = question.Id > 0 ?
						currentQuestions.First(q => q.Id == question.Id)
						: questionMappingDict[question.Id];

					if (question.NextQuestionId.HasValue)
					{
						if(question.NextQuestionId > 0)
						{
							questionToLink.NextQuestionId = question.NextQuestionId;
						}
						else if(question.NextQuestionId < 0)
						{
							var nextQuestion = questionMappingDict[question.NextQuestionId.Value];
							questionToLink.NextQuestionId = nextQuestion.Id;
						}
					}
					_questionRepository.Update(questionToLink);

					foreach (var option in question.Options)
					{
						var optionToLink = option.Id > 0 ?
							currentOptions.First(o => o.Id == option.Id)
							: optionMappingDict[option.Id];

						if (option.NextQuestionId.HasValue)
						{
							if(option.NextQuestionId > 0)
							{
								optionToLink.NextQuestionId = option.NextQuestionId;
							}
							else
							{
								var nextQuestion = questionMappingDict[option.NextQuestionId.Value];
								optionToLink.NextQuestionId = nextQuestion.Id;
							}	
						}

						_optionRepository.Update(optionToLink);
					}
				}
				success = true;
			}
			catch
			{

			}

			return new JsonResult(new { success, message });
		}

		[HttpPost("{serviceInfoId}/questionnaire/delete")]
		public IActionResult DeleteQuestionnaire(int serviceInfoId)
		{
			var success = false;
			var message = string.Empty;

			try
			{
				var questionsToDelete = _questionRepository.Table.Include(q => q.Options)
					.Where(q => q.ServiceInfoId == serviceInfoId)
					.ToArray();

				_questionRepository.Delete(questionsToDelete);
				success = true;
			}
			catch
			{

			}

			return new JsonResult(new { success, message });
		}

		private bool IsValidQuestionnaireModel(QuestionnaireModel model)
		{
			var options = model.Questions.SelectMany(q => q.Options).ToArray();

			var optionGenIds = options.Where(o => o.Id < 0).Select(o => o.Id).ToArray();
			var optionIds = options.Where(o => o.Id > 0).Select(o => o.Id).ToArray();

			if ((optionGenIds.Count() > 0 && optionGenIds.Count() != optionGenIds.Distinct().Count())
			|| (optionIds.Count() > 0 && optionIds.Count() != optionIds.Distinct().Count()))
			{
				return false;
			}

			var questionGenIds = model.Questions.Where(q => q.Id < 0).Select(q => q.Id).ToArray();
			var questionIds = model.Questions.Where(q => q.Id > 0).Select(q => q.Id).ToArray();

			if ((questionGenIds.Count() > 0 && questionGenIds.Count() != questionGenIds.Distinct().Count()) ||
			(questionIds.Count() > 0 && questionIds.Count() != questionIds.Distinct().Count()))
			{
				return false;
			}

			if (model.Questions.Any(q => q.NextQuestionId.HasValue && q.NextQuestionId.Value < 0 && !questionGenIds.Contains(q.NextQuestionId.Value))
			|| options.Any(o => o.NextQuestionId.HasValue && o.NextQuestionId.Value < 0 && !questionGenIds.Contains(o.NextQuestionId.Value)))
			{
				return false;
			}

			if (model.Questions.Any(q => q.NextQuestionId.HasValue && q.NextQuestionId.Value > 0 && !questionIds.Contains(q.NextQuestionId.Value))
			|| options.Any(o => o.NextQuestionId.HasValue && o.NextQuestionId.Value > 0 && !questionIds.Contains(o.NextQuestionId.Value)))
			{
				return false;
			}

			return true;
		}


		#endregion

		#region Name Tokens
		[HttpGet("{serviceInfoId}/name-tokens")]
		public IActionResult GetServiceInfoNameTokensByServiceInfoId(int serviceInfoId)
		{
			var nameTokens = _serviceInfoNameTokenRepository.TableNoTracking.Include(st => st.NameToken)
				.Where(t => t.ServiceInfoId == serviceInfoId)
				.Select(st => st.NameToken).ToArray();

			return new JsonResult(nameTokens);
		}
		#endregion
	}
}