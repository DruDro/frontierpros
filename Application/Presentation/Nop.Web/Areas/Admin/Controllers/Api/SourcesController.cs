using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Sources;
using FrontierPros.Services.Catalog;
using FrontierPros.Services.Sources;
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
	public class SourcesController : BaseController
	{
		private readonly IRepository<QuestionSource> _questionSourceRepository;
		private readonly IRepository<SpecialtySource> _specialtyRepository;
		private readonly IServiceInfoSourceService _serviceInfoSourceService;
		private readonly IServiceCategorySourceService _serviceCategorySourceService;

		private readonly IRepository<ServiceInfoSourceAndNameTokenSource> _serviceInfoSourceNameTokenRepository;


		public SourcesController(IRepository<ServiceInfoSource> serviceInfoSourceRepository,
									IRepository<ServiceCategorySource> groupSourceRepository,
									IRepository<QuestionSource> clientQuestionRepository,
									IRepository<SpecialtySource> specialtyRepository,
									IRepository<ServiceInfoSourceAndNameTokenSource> serviceInfoSourceNameTokenRepository,
									IServiceInfoService serviceInfoService,
									IServiceInfoSourceService serviceInfoSourceService,
									IServiceCategorySourceService serviceCategorySourceService)
		{
			this._questionSourceRepository = clientQuestionRepository;
			this._specialtyRepository = specialtyRepository;
			this._serviceInfoSourceNameTokenRepository = serviceInfoSourceNameTokenRepository;
			this._serviceInfoSourceService = serviceInfoSourceService;
			this._serviceCategorySourceService = serviceCategorySourceService;
		}

		[HttpGet("services/{id}")]
		public IActionResult GetServiceInfoSourceById(int id)
		{
			var serviceInfoSource = _serviceInfoSourceService.GetServiceInfoSourceById(id);
			if(serviceInfoSource == null) return new JsonResult(null);
			var serviceInfoDto = new
			{
				serviceInfoSource.Id,
				serviceInfoSource.Name
			};
			return new JsonResult(serviceInfoDto);
		}

		[HttpPost("services")]
		public IActionResult GetServiceInfoSources(ServiceInfoFilterModel filter)
		{
			var serviceInfoEntities = _serviceInfoSourceService.GetAllServiceInfoSources(filter.Name, filter.PageIndex, filter.PageSize, showHidden:true);

			var serviceInfoDtos = serviceInfoEntities.Select(c => new {
				c.Id,
				c.Name
			}).ToArray();

			return new JsonResult(serviceInfoDtos);
		}

		[HttpGet("service-categories")]
		public IActionResult GetServiceCategorySources()
		{
			var serviceCategoryDtos = _serviceCategorySourceService.GetAllServiceCategorySources(showHidden:true)
				.Select(c => new {
					c.Id,
					c.Name
				}).ToArray();

			return new JsonResult(serviceCategoryDtos);
		}

		[HttpGet("service-categories/{serviceCategoryId}/services")]
		public IActionResult GetServices(int serviceCategoryId)
		{
			var serviceInfoEntities = _serviceCategorySourceService.GetServices(serviceCategoryId, true);
			var serviceInfoDtos = serviceInfoEntities.Select(s => new
			{
				s.Id,
				s.Name
			}).ToArray();

			return new JsonResult(serviceInfoDtos);
		}

		[HttpGet("services/{serviceInfoSourceId}/questionnaire")]
		public IActionResult GetQuestionnaireSourcesByServiceInfoSourceId(int serviceInfoSourceId)
		{
			var questions = _questionSourceRepository.TableNoTracking.Include(q => q.Options)
				.Where(q => q.ServiceInfoSourceId == serviceInfoSourceId)
				.OrderByDescending(q => q.IsStartQuestion)
				.OrderBy(q => q.Order)
				.Select(q => new {
					Id = -q.Id,
					q.ProviderHeading,
					q.ProviderSubHeading,
					q.Heading,
					q.SubHeading,
					q.Placeholder,
					Type = q.Type.ToString(),
					NextQuestionId = q.NextQuestionSourceId.HasValue ? -q.NextQuestionSourceId.Value : q.NextQuestionSourceId,
					q.IsRequired,
					q.IsStartQuestion,
					q.IsProviderQuestion,
					q.IsPaidQuestion,
					q.Order,
					Options = q.Options.OrderBy(o => o.Order).Select(o => new {
						Id = -o.Id,
						o.ProviderText,
						o.Text,
						o.Order,
						NextQuestionId = o.NextQuestionSourceId.HasValue ? -o.NextQuestionSourceId.Value : o.NextQuestionSourceId
					})
					.ToArray(),
				})
				.ToArray();

			return new JsonResult(questions);
		}


		[HttpGet("services/{serviceInfoSourceId}/name-tokens")]
		public IActionResult GetServiceInfoSourceNameTokensByServiceInfoSourceId(int serviceInfoSourceId)
		{
			var nameTokens = _serviceInfoSourceNameTokenRepository.TableNoTracking.Include(st => st.NameToken)
				.Where(t => t.ServiceInfoSourceId == serviceInfoSourceId)
				.Select(st => st.NameToken).ToArray();

			return new JsonResult(nameTokens);
		}
	}
}