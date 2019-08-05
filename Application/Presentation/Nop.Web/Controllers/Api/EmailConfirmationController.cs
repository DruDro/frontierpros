using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Providers;
using FrontierPros.Core.Domain.Questions;
using FrontierPros.Core.Domain.Specialties;
using FrontierPros.Services.ADB2CGraph;
using FrontierPros.Services.Catalog;
using FrontierPros.Services.Customers;
using FrontierPros.Services.Messages;
using FrontierPros.Services.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.EmailConfirmation;

namespace Nop.Web.Controllers.Api
{
    [Route("api/email-confirmation")]
    [ApiController]
    public class EmailConfirmationController : ControllerBase
    {
		private readonly ICodeVerificationService _codeVerificationService;
		private readonly IWorkContext _workContext;
		private readonly IGenericAttributeService _genericAttributeService;
		private readonly IProviderService _providerService;
		private readonly ICustomerService _customerService;
		private readonly IB2CGraphService _b2CGraphService;

		public EmailConfirmationController(ICodeVerificationService codeVerificationService, 
											IWorkContext workContext, 
											IGenericAttributeService genericAttributeService,
											IProviderService providerService,
											ICustomerService customerService,
											IB2CGraphService b2CGraphService)
		{
			this._codeVerificationService = codeVerificationService;
			this._workContext = workContext;
			this._genericAttributeService = genericAttributeService;
			this._providerService = providerService;
			this._b2CGraphService = b2CGraphService;
			this._customerService = customerService;
		}

		[HttpPost]
		public IActionResult Index(EmailConfirmationModel model)
		{
			var isSuccess = false;
			var errorMessage = string.Empty;

			if (User.Identity.IsAuthenticated)
			{
				var customer = _workContext.CurrentCustomer;
				if (customer != null)
				{
					isSuccess = _codeVerificationService.SendCodeOnEmail(customer.Id, model.Email, _workContext.WorkingLanguage.Id);
					if (isSuccess)
					{
						_genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.UnverifiedEmailAttribute, model.Email);
					}
					else
					{
						errorMessage = "Confirmation code was not sent";
					}
				}
			}

			return new JsonResult(new { success = isSuccess, errorMessage });
		}

		[HttpPost("verify")]
		public async Task<IActionResult> Verify(EmailCodeVerificationModel model)
		{
			var isSuccess = false;

			if (User.Identity.IsAuthenticated)
			{
				var customer = _customerService.GetCustomerById(_workContext.CurrentCustomer.Id);
				if (customer != null)
				{
					isSuccess = _codeVerificationService.IsEmailCodeValid(customer.Id, model.Code);
					if (isSuccess)
					{
						try
						{
							var email = _genericAttributeService.GetAttribute<string>(customer, ExtendedCustomerDefaults.UnverifiedEmailAttribute);
							if (!string.IsNullOrEmpty(email) && _customerService.GetCustomerByEmail(email) == null)
							{
								customer.Email = email;
								_customerService.UpdateCustomer(customer);
								if (customer.IsInCustomerRole(ExtendedCustomerDefaults.ProvidersRoleName))
								{
									var provider = _providerService.GetProviderByCustomerId(customer.Id);
									if (provider != null)
									{
										provider.Email = email;
										await _providerService.UpdateProviderAsync(provider);
									}
								}

								var externalAuthenticationRecord = customer.ExternalAuthenticationRecords.FirstOrDefault(r => r.ProviderSystemName == "ExternalAuth.ActiveDirectoryB2C");
								if (externalAuthenticationRecord != null)
								{
									var patch = new
									{
										signInNames = new List<object>()
									{
										new {
											type = "emailAddress",
											value = email
										}
									}
									};
									await _b2CGraphService.UpdateUserAsync(externalAuthenticationRecord.ExternalIdentifier, patch);
								}
							}
							else
							{
								isSuccess = false;
							}

						}
						catch
						{
							isSuccess = false;
						}
					}
				}
			}

			return new JsonResult(new { success = isSuccess });
		}
	}
}