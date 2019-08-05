using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Questions;
using FrontierPros.Core.Domain.Specialties;
using FrontierPros.Services.Catalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Data;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Services;

namespace Nop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
		private readonly IRepository<Question> _questionRepository;
		private readonly IRepository<Specialty> _specialtyRepository;
		private readonly IServiceInfoService _serviceInfoService;

		public ServicesController(IRepository<Question> questionRepository,
									IRepository<Specialty> specialtyRepository,
									IServiceInfoService serviceInfoService)
		{
			this._questionRepository = questionRepository;
			this._specialtyRepository = specialtyRepository;
			this._serviceInfoService = serviceInfoService;
		}

		[HttpGet("{id?}")]
		public IActionResult Index(int id)
		{
			var serviceInfo = _serviceInfoService.GetServiceInfoById(id);

			if (serviceInfo == null)
			{
				return new JsonResult(null);
			}

			var serviceInfoDto = new
			{
				serviceInfo.Id,
				serviceInfo.Name,
			};

			return new JsonResult(serviceInfoDto);
		}

		[HttpPost]
		public IActionResult Index(ServiceInfoFilterModel filter)
		{
			var serviceInfoEntities = _serviceInfoService.GetAllServiceInfoEntities(filter.Name, filter.PageIndex, filter.PageSize);

			var serviceInfoDtos = serviceInfoEntities.Select(c => new {
				c.Id,
				c.Name,
			}).ToArray();

			return new JsonResult(serviceInfoDtos);
		}

		[HttpGet("{serviceInfoId}/client-questions")]
		public IActionResult GetClientQuestionsByServiceInfoId(int serviceInfoId)
		{
			var questions = _questionRepository.TableNoTracking.Include(q => q.Options)
				.Where(q => q.ServiceInfoId == serviceInfoId)
				.OrderByDescending(q => q.IsStartQuestion)
				.Select(q => new {
					q.Id,
					q.Heading,
					q.SubHeading,
					q.Placeholder,
					Type = q.Type.ToString(),
					q.NextQuestionId,
					q.IsRequired,
					q.IsStartQuestion,
					Options = q.Options.OrderBy(o => o.Order).Select(o=>new {
						o.Id,
						o.Text,
						o.Order,
						o.NextQuestionId
					})
					.ToArray(),
				})
				.ToArray();

			return new JsonResult(questions);
		}

		[HttpGet("{serviceInfoId}/provider-questions")]
		public IActionResult GetProviderQuestionsByServiceInfoId(int serviceInfoId)
		{
			var questions = _questionRepository.TableNoTracking.Include(q => q.Options)
				.Where(q => q.ServiceInfoId == serviceInfoId && q.IsProviderQuestion)
				.OrderBy(q => q.Order)
				.Select(q => new {
					q.Id,
					q.ProviderHeading,
					q.ProviderSubHeading,
					Type = q.Type.ToString(),
					q.NextQuestionId,
					q.IsRequired,
					q.IsStartQuestion,
					q.IsPaidQuestion,
					q.Order,
					Options = q.Options.OrderBy(o => o.Order).Select(o => new {
						o.Id,
						o.ProviderText,
						o.Order,
						o.NextQuestionId
					})
					.ToArray(),
				})
				.ToArray();

			return new JsonResult(questions);
		}

		[HttpGet("{serviceInfoId}/specialties")]
		public IActionResult GetSpecialtiesByServiceInfoId(int serviceInfoId)
		{
			var specialties = _specialtyRepository.TableNoTracking.Include(s => s.Options)
				.Where(s => s.ServiceInfoId == serviceInfoId)
				.OrderBy(s => s.ServiceInfoId).ThenBy(s => s.Order).Select(s => new {
				s.Id,
				s.Heading,
				Options = s.Options.Select(o => new {
					o.Id,
					o.Text
				}).ToArray()
			}).ToArray();
			return new JsonResult(specialties);
		}
	}
}