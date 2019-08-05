using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Services.Customers;
using FrontierPros.Services.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Models.Profile;
using Nop.Web.Validators.Files;

namespace Nop.Web.Controllers.Api
{
	[Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IProviderService _providerService;
		private readonly ICustomerMediaFileService _customerMediaFileService;

        public CustomerController(ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
            IWorkContext workContext, IProviderService providerService,
			ICustomerMediaFileService customerMediaFileService)
        {
            _customerService = customerService;
            _workContext = workContext;
            _genericAttributeService = genericAttributeService;
            _providerService = providerService;
			_customerMediaFileService = customerMediaFileService;
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                return new JsonResult(null);
            }

            var customerId = _workContext.CurrentCustomer.Id;
            var member = _customerService.GetCustomerById(customerId);
            if (member == null) return new JsonResult(null);

            var data = new Dictionary<string, string>();

            if (member.CustomerRoles.Any(cr => cr.SystemName == ExtendedCustomerDefaults.MembersRoleName))
            {
				data = _genericAttributeService.GetAttributesForEntity(member.Id, nameof(Customer)).ToDictionary(d => d.Key, d => d.Value);
				data.Add("Id", member.Id.ToString());
				data.Add("Email", member.Email);
				// add some data to result
			}

            return new JsonResult(data);
        }

        [HttpPost("profile")]
        public IActionResult SetProfile(CustomerProfileModel model)
        {
            var success = false;
            var message = string.Empty;
			var customerId = _workContext.CurrentCustomer.Id;

			if (customerId != model.Id)
			{
				Response.StatusCode = StatusCodes.Status403Forbidden;
				return new JsonResult(null);
			}

			try
            {
                var memberToUpdate = _customerService.GetCustomerById(model.Id);
                if (memberToUpdate != null && memberToUpdate.CustomerRoles.Any(r => r.SystemName == ExtendedCustomerDefaults.MembersRoleName))
                {
                    memberToUpdate.Email = model.Email;

                    _genericAttributeService.SaveAttribute(memberToUpdate, ExtendedCustomerDefaults.NameAttribute, model.Name);
                    _genericAttributeService.SaveAttribute(memberToUpdate, ExtendedCustomerDefaults.CountryAttribute, model.Country);
                    _genericAttributeService.SaveAttribute(memberToUpdate, NopCustomerDefaults.PhoneAttribute, model.Phone);
                    _genericAttributeService.SaveAttribute(memberToUpdate, NopCustomerDefaults.CityAttribute, model.City);
                    _genericAttributeService.SaveAttribute(memberToUpdate, NopCustomerDefaults.StreetAddressAttribute, model.StreetAddress);

                    //update cutomer fields

                    success = true;
                }
            }
            catch
            {

            }

            return new JsonResult(new { success, message });
        }

		#region Uploaders

		[HttpPost("profile/icon")]
		public async Task<IActionResult> SaveCustomerIcon(IFormFile file)
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				if (!User.Identity.IsAuthenticated)
				{
					return new JsonResult(new { success, errorMessage });
				}

				if (!FileValidator.ValidateIcon(file, ref errorMessage))
				{
					return new JsonResult(new { success, errorMessage });
				}
				var customerId = _workContext.CurrentCustomer.Id;
				await _customerMediaFileService.DeleteCustomerIconAsync(customerId);
				await _customerMediaFileService.InsertCustomerIconAsync(customerId, file);
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}
			
			return new JsonResult(new { success, errorMessage });
		}

		[HttpDelete("profile/icon")]
		public async Task<IActionResult> DeleteCustomerIcon()
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				if (!User.Identity.IsAuthenticated)
				{
					Response.StatusCode = StatusCodes.Status401Unauthorized;
					return new JsonResult(new { success, errorMessage });
				}

				var customerId = _workContext.CurrentCustomer.Id;
				await _customerMediaFileService.DeleteCustomerIconAsync(customerId);
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage });
		}

		[HttpPost("profile/media")]
		public async Task<IActionResult> SaveCustomerMediaFile([FromForm]CustomerFileModel model)
		{
			var success = false;
			var errorMessage = string.Empty;
			CustomerMediaFile mediaFile = null;
			
			try
			{
				if (!User.Identity.IsAuthenticated)
				{
					Response.StatusCode = StatusCodes.Status401Unauthorized;
					return new JsonResult(new { success, errorMessage });
				}

				if (model.File != null && !FileValidator.ValidateMediaFile(model.File, ref errorMessage))
				{
					return new JsonResult(new { success, errorMessage });
				}

				var customerId = _workContext.CurrentCustomer.Id;
				mediaFile = await _customerMediaFileService.InsertCustomerMediaFileAsync(customerId, model);
				mediaFile.Customer = null;
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage, mediaFile });
		}

		[HttpPut("profile/media/{id}")]
		public IActionResult EditMedia(int id, CustomerEditMediaFileModel model)
		{
			var success = false;
			var errorMessage = string.Empty;
			CustomerMediaFile mediaFile = null;

			try
			{
				if (!User.Identity.IsAuthenticated)
				{
					Response.StatusCode = StatusCodes.Status401Unauthorized;
					return new JsonResult(new { success, errorMessage });
				}

				if (id != model.Id)
				{
					Response.StatusCode = StatusCodes.Status400BadRequest;
					return new JsonResult(new { success, errorMessage });
				}

				mediaFile = _customerMediaFileService.UpdateCustomerMediaFile(model);
				mediaFile.Customer = null;
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage, mediaFile });
		}

		[HttpDelete("profile/media/{Id}")]
		public async Task<IActionResult> DeleteCustomerMediaFile(int id)
		{
			var success = false;
			var errorMessage = string.Empty;

			try
			{
				if (!User.Identity.IsAuthenticated)
				{
					Response.StatusCode = StatusCodes.Status401Unauthorized;
					return new JsonResult(new { success, errorMessage });
				}

				var customerId = _workContext.CurrentCustomer.Id;
				var mediaFile = _customerMediaFileService.GetCustomerMediaFileById(id);
				if (mediaFile != null)
				{
					if(mediaFile.CustomerId != customerId)
					{
						Response.StatusCode = StatusCodes.Status403Forbidden;
						return new JsonResult(new { success, errorMessage });
					}

					await _customerMediaFileService.DeleteCustomerMediaFileAsync(mediaFile);
				}
				success = true;
			}
			catch
			{
				errorMessage = "error";
			}

			return new JsonResult(new { success, errorMessage });
		}
		#endregion
	}
}