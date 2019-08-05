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
using Nop.Web.Models.Catalog;

namespace Nop.Web.Controllers.Api
{
    [Route("api/service-categories")]
    [ApiController]
    public class ServiceCategoriesController : ControllerBase
    {
		private readonly IServiceCategoryService _serviceCategoryService;

		public ServiceCategoriesController(IServiceCategoryService serviceCategoryService)
		{
			this._serviceCategoryService = serviceCategoryService;
		}

		[HttpGet("{id?}")]
		public IActionResult Index(int? id = null)
		{
			if (id.HasValue)
			{
				var serviceCategory = _serviceCategoryService.GetServiceCategoryById(id.Value);
				var serviceCategoryDto = new
				{
					serviceCategory.Id,
					serviceCategory.Name
				};

				return new JsonResult(serviceCategoryDto);
			}

			var serviceCategories = _serviceCategoryService.GetAllServiceCategories();
			var serviceCategoryDtos = serviceCategories
				.Select(sc => new {
					sc.Id,
					sc.Name
				}).ToArray();

			return new JsonResult(serviceCategoryDtos);
		}

		[HttpGet("{serviceCategoryId}/services")]
		public IActionResult GetServices(int serviceCategoryId)
		{
			var serviceInfoEntities = _serviceCategoryService.GetServices(serviceCategoryId);
			var serviceInfoDtos = serviceInfoEntities.Select(s => new
			{
				s.Id,
				s.Name
			}).ToArray();

			return new JsonResult(serviceInfoDtos);
		}
	}
}