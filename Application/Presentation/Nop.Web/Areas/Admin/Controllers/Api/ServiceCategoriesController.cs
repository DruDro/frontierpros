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

namespace Nop.Web.Areas.Admin.Controllers.Api
{
    [Route("api/[area]/service-categories")]
    [ApiController]
	[Area(AreaNames.Admin)]
	//[HttpsRequirement(SslRequirement.Yes)]
	//[AuthorizeAdmin]
	public class ServiceCategoriesController : BaseController
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
					serviceCategory.Name,
					serviceCategory.Published
				};

				return new JsonResult(serviceCategoryDto);
			}

			var serviceCategories = _serviceCategoryService.GetAllServiceCategories(showHidden:true);
			var serviceCategoryDtos = serviceCategories
				.Select(sc => new {
					sc.Id,
					sc.Name,
					sc.Published
				}).ToArray();

			return new JsonResult(serviceCategoryDtos);
		}

		[HttpGet("{serviceCategoryId}/services")]
		public IActionResult GetServices(int serviceCategoryId)
		{
			var serviceInfoEntities = _serviceCategoryService.GetServices(serviceCategoryId,true);
			var serviceInfoDtos = serviceInfoEntities.Select(s => new
			{
				s.Id,
				s.Name
			}).ToArray();

			return new JsonResult(serviceInfoDtos);
		}


		[HttpPost("add")]
		public IActionResult Add(CreateServiceCategoryModel model)
		{
			var success = false;
			var message = string.Empty;
			var id = -1;

			try
			{
				var existingServiceCategory = _serviceCategoryService.GetServiceCategoryByName(model.Name);
				if (existingServiceCategory != null)
				{
					id = existingServiceCategory.Id;
				}
				else
				{
					var serviceCategoryToAdd = new ServiceCategory()
					{
						Name = model.Name,
						CreatedOnUtc = DateTime.UtcNow,
						UpdatedOnUtc = DateTime.UtcNow
					};

					_serviceCategoryService.InsertServiceCategory(serviceCategoryToAdd);
					id = serviceCategoryToAdd.Id;
				}
				success = true;
			}
			catch
			{

			}

			return new JsonResult(new { id, success, message });
		}

		[HttpPost("edit")]
		public IActionResult Edit(EditServiceCategoryModel model)
		{
			var success = false;
			var message = string.Empty;

			try
			{
				var serviceCategoryToUpdate = _serviceCategoryService.GetServiceCategoryById(model.Id);
				var serviceCategoryByName = _serviceCategoryService.GetServiceCategoryByName(model.Name);

				if (serviceCategoryToUpdate != null 
					&& (serviceCategoryByName == null || serviceCategoryByName.Id == serviceCategoryToUpdate.Id))
				{
					serviceCategoryToUpdate.Name = model.Name;
					serviceCategoryToUpdate.UpdatedOnUtc = DateTime.UtcNow;
					_serviceCategoryService.UpdateServiceCategory(serviceCategoryToUpdate);
					success = true;
				}
				else
				{
					message = "Service Category already exists";
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
				var serviceCategoryToDelete = _serviceCategoryService.GetServiceCategoryById(id);
				if (serviceCategoryToDelete != null)
				{
					_serviceCategoryService.DeleteServiceCategory(serviceCategoryToDelete);
					success = true;
				}
			}
			catch
			{

			}

			return new JsonResult(new { success, message });
		}
	}
}