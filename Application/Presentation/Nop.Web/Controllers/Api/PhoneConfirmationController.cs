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
using FrontierPros.Services.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.PhoneConfirmation;

namespace Nop.Web.Controllers.Api
{
    [Route("api/phone-confirmation")]
    [ApiController]
    public class PhoneConfirmationController : ControllerBase
    {
		private readonly ICodeVerificationService _codeVerificationService;
		private readonly IWorkContext _workContext;
		private readonly IGenericAttributeService _genericAttributeService;
		private readonly IProviderService _providerService;
		private readonly IB2CGraphService _b2CGraphService;

		public PhoneConfirmationController(ICodeVerificationService codeVerificationService, 
											IWorkContext workContext, 
											IGenericAttributeService genericAttributeService,
											IProviderService providerService,
											IB2CGraphService b2CGraphService)
		{
			this._codeVerificationService = codeVerificationService;
			this._workContext = workContext;
			this._genericAttributeService = genericAttributeService;
			this._providerService = providerService;
			this._b2CGraphService = b2CGraphService;
		}

		[HttpPost]
		public IActionResult Index(PhoneConfirmationModel model)
		{
			var isSuccess = true;

			//if (User.Identity.IsAuthenticated)
			//{
			//	var customer = _workContext.CurrentCustomer;
			//	if (customer != null)
			//	{
			//		isSuccess = _codeVerificationService.SendCodeOnPhoneNumber(customer.Id, model.PhoneNumber);
			//		if (isSuccess)
			//		{
			//			_genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.PhoneAttribute, model.PhoneNumber);
			//			_genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.PhoneVerifiedAttribute, false);
			//		}
			//		else
			//		{
			//			return new JsonResult(new { success = isSuccess, errorMessage = "Confirmation code was not sent" });
			//		}
			//	}
			//}
			var customer = _workContext.CurrentCustomer;
			if (customer != null)
			{
				_genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.PhoneAttribute, model.PhoneNumber);
				_genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.PhoneVerifiedAttribute, false);
			}

			return new JsonResult(new { success = isSuccess });
		}

		[HttpPost("verify")]
		public async Task<IActionResult> Verify(CodeVerificationModel model)
		{
			var isSuccess = false;

			if (User.Identity.IsAuthenticated)
			{
				var customer = _workContext.CurrentCustomer;
				if (customer != null)
				{
					isSuccess = true;//_codeVerificationService.IsPhoneCodeValid(customer.Id, model.Code);
					if (isSuccess)
					{
						try
						{
							_genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.PhoneVerifiedAttribute, true);
							var phoneNumber = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.PhoneAttribute);

							if (customer.IsInCustomerRole(ExtendedCustomerDefaults.ProvidersRoleName))
							{
								var provider = _providerService.GetProviderByCustomerId(customer.Id);
								if (provider != null)
								{
									provider.PersonalPhoneNumber = phoneNumber;
									provider.Progress = provider.Progress | ProviderAccountProgress.PHONE_CONFIRMATION;
									await _providerService.UpdateProviderAsync(provider);
								}
							}

							var externalAuthenticationRecord = customer.ExternalAuthenticationRecords.FirstOrDefault(r => r.ProviderSystemName == "ExternalAuth.ActiveDirectoryB2C");
							if (externalAuthenticationRecord != null)
							{
								var patch = new
								{
									telephoneNumber = phoneNumber
								};
								await _b2CGraphService.UpdateUserAsync(externalAuthenticationRecord.ExternalIdentifier, patch);
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