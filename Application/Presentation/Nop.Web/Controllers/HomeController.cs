using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Providers;
using FrontierPros.Services.ADB2CGraph;
using FrontierPros.Services.Customers;
using FrontierPros.Services.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Security;
using Nop.Web.Models.Customer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
		#region Fields
		private readonly CustomerSettings _customerSettings;
		private readonly ICustomerService _customerService;
		private readonly ICustomerRegistrationService _customerRegistrationService;
		private readonly IStoreContext _storeContext;
		private readonly IGenericAttributeService _genericAttributeService;
		private readonly IAuthenticationService _authenticationService;
        private readonly IProviderService _providerService;
		private readonly IB2CGraphService _b2CGraphService;

		private readonly IWorkContext _workContext;
		private readonly ICodeVerificationService _codeVerificationService;

		#endregion

		#region Ctor
		public HomeController(ICustomerService customerService,
			ICustomerRegistrationService customerRegistrationService,
			CustomerSettings customerSettings,
			IStoreContext storeContext,
			IGenericAttributeService genericAttributeService,
			IAuthenticationService authenticationService,
            IProviderService serviceProviderService,
			IB2CGraphService b2CGraphService,
			IWorkContext workContext,
			ICodeVerificationService codeVerificationService)
		{
			_customerService = customerService;
			_customerRegistrationService = customerRegistrationService;
			_customerSettings = customerSettings;
			_storeContext = storeContext;
			_genericAttributeService = genericAttributeService;
			_authenticationService = authenticationService;
            _providerService = serviceProviderService;
			_b2CGraphService = b2CGraphService;
			_workContext = workContext;
			_codeVerificationService = codeVerificationService;
		}
		#endregion
		[HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpsRequirement(SslRequirement.No)]
		[HttpGet("provider")]
        public virtual IActionResult Provider()
        {
            return View();
        }

        [HttpPost("signup-customer")]
		public virtual IActionResult SignUp(MemberRegisterModel model)
		{
			if (!ValidateCustomer(ModelState)) return View(model);

			var customer = new Customer();
			customer.CreatedOnUtc = DateTime.UtcNow;
			var roles = _customerService.GetAllCustomerRoles().ToDictionary(r => r.SystemName);

			customer.CustomerCustomerRoleMappings.Add(new CustomerCustomerRoleMapping() { CustomerRole = roles[ExtendedCustomerDefaults.MembersRoleName] });

			var isApproved = _customerSettings.UserRegistrationType == UserRegistrationType.Standard;
			var registrationRequest = new CustomerRegistrationRequest(customer,
				model.Email,
				_customerSettings.UsernamesEnabled ? model.Username : model.Email,
				model.Password,
				_customerSettings.DefaultPasswordFormat,
				_storeContext.CurrentStore.Id,
				isApproved);

			var registrationResult = _customerRegistrationService.RegisterCustomer(registrationRequest);
			if (registrationResult.Success)
			{
				_genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.FirstNameAttribute, model.FirstName);
				_genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.LastNameAttribute, model.LastName);
				_genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.PhoneAttribute, model.Phone);


				_authenticationService.SignIn(customer, true);
				return RedirectToAction("Index", "Home");
			}

			foreach (var error in registrationResult.Errors)
				ModelState.AddModelError("", error);

			return View(model);
		}

		[HttpPost("signup-provider")]
		public virtual IActionResult SignUpProvider(ProviderRegisterModel model)
		{
			if (!ValidateProvider(ModelState)) return View(model);

			var customer = new Customer();
			customer.CreatedOnUtc = DateTime.UtcNow;

			var role = _customerService.GetCustomerRoleBySystemName(ExtendedCustomerDefaults.ProvidersRoleName);
			customer.CustomerCustomerRoleMappings.Add(new CustomerCustomerRoleMapping() { CustomerRole = role });

			var isApproved = _customerSettings.UserRegistrationType == UserRegistrationType.Standard;
			var registrationRequest = new CustomerRegistrationRequest(customer,
				model.Email,
				_customerSettings.UsernamesEnabled ? model.Username : model.Email,
				model.Password,
				_customerSettings.DefaultPasswordFormat,
				_storeContext.CurrentStore.Id,
				isApproved);

			var registrationResult = _customerRegistrationService.RegisterCustomer(registrationRequest);
			if (registrationResult.Success)
			{
                var createdCustomer = _customerService.GetCustomerByEmail(model.Email);

                var provider = new Provider
                {
                    Customer = createdCustomer,
                    CustomerId = createdCustomer.Id,
					Email = createdCustomer.Email
                };

                _providerService.InsertProvider(provider);

				_genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.PhoneAttribute, model.Phone);
				_authenticationService.SignIn(customer, true);

				return RedirectToAction("Index", "Home");
			}

			foreach (var error in registrationResult.Errors)
				ModelState.AddModelError("", error);

			return View(model);
		}

		#region Validation

		private bool ValidateCustomer(ModelStateDictionary modelState)
		{
			if (modelState.GetFieldValidationState(nameof(MemberRegisterModel.Email)) != ModelValidationState.Valid) return false;
			if (modelState.GetFieldValidationState(nameof(MemberRegisterModel.Phone)) != ModelValidationState.Valid) return false;
			if (modelState.GetFieldValidationState(nameof(MemberRegisterModel.Password)) != ModelValidationState.Valid) return false;
			if (modelState.GetFieldValidationState(nameof(MemberRegisterModel.ConfirmPassword)) != ModelValidationState.Valid) return false;
			
			ModelState.Clear();
			return true;
		}

		private bool ValidateProvider(ModelStateDictionary modelState)
		{
			if (modelState.GetFieldValidationState(nameof(ProviderRegisterModel.Email)) != ModelValidationState.Valid) return false;
			if (modelState.GetFieldValidationState(nameof(ProviderRegisterModel.Phone)) != ModelValidationState.Valid) return false;
			if (modelState.GetFieldValidationState(nameof(ProviderRegisterModel.Password)) != ModelValidationState.Valid) return false;
			if (modelState.GetFieldValidationState(nameof(ProviderRegisterModel.ConfirmPassword)) != ModelValidationState.Valid) return false;

			ModelState.Clear();
			return true;
		}

		#endregion

		[HttpGet("upload")]
		public IActionResult UploadTest() {
			return View();
		}

		[HttpGet("btctest")]
		public async Task<string> B2CTest()
		{
			return await _b2CGraphService.UpdateUserAsync("022b2083-ef46-4381-bd43-65b6c4b95e5d", "{displayName: 'Display Name'}");
		}

		[HttpGet("emailtest")]
		public string EmailTest()
		{
			var customer = _workContext.CurrentCustomer;
			_codeVerificationService.SendCodeOnEmail(customer.Id, customer.Email, _workContext.WorkingLanguage.Id);
			return string.Empty;
		}
	}
}