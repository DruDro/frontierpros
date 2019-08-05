using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Providers;
using FrontierPros.Services.Providers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nop.Core;
using Nop.Core.Domain;
using Nop.Core.Domain.Customers;
using Nop.Plugin.ExternalAuth.ActiveDirectoryB2C.Models;
using Nop.Services.Authentication.External;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using NopAuthentication = Nop.Services.Authentication.IAuthenticationService;

namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C.Controllers
{
	public class ActiveDirectoryB2CClaimTypes
	{
		public static string ObjectIdentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";
		public static string Emails = "emails";
		public static string FullName = "name";
	}
	public class ActiveDirectoryB2CAuthenticationController : BasePluginController
	{
		#region Fields

		private readonly ActiveDirectoryB2CExternalAuthSettings _activeDirectoryB2CExternalAuthSettings;
		private readonly IExternalAuthenticationService _externalAuthenticationService;
		private readonly ILocalizationService _localizationService;
		private readonly IOptionsMonitorCache<AzureADB2COptions> _optionsCache;
		private readonly IPermissionService _permissionService;
		private readonly ISettingService _settingService;

		private readonly CustomerSettings _customerSettings;
		private readonly ICustomerService _customerService;
		private readonly ICustomerRegistrationService _customerRegistrationService;
		private readonly IStoreContext _storeContext;
		private readonly IGenericAttributeService _genericAttributeService;
		private readonly NopAuthentication _authenticationService;
		private readonly IProviderService _providerService;

		private readonly IWorkContext _workContext;
		private readonly ICustomerActivityService _customerActivityService;
		private readonly StoreInformationSettings _storeInformationSettings;
		private readonly IEventPublisher _eventPublisher;

		#endregion

		#region Ctor

		public ActiveDirectoryB2CAuthenticationController(ActiveDirectoryB2CExternalAuthSettings ActiveDirectoryExternalAuthSettings,
			IExternalAuthenticationService externalAuthenticationService,
			ILocalizationService localizationService,
			IOptionsMonitorCache<AzureADB2COptions> optionsCache,
			IPermissionService permissionService,
			ISettingService settingService,
			ICustomerService customerService,
			ICustomerRegistrationService customerRegistrationService,
			CustomerSettings customerSettings,
			IStoreContext storeContext,
			IGenericAttributeService genericAttributeService,
			NopAuthentication authenticationService,
			IProviderService serviceProviderService,
			StoreInformationSettings storeInformationSettings,
			IWorkContext workContext,
			ICustomerActivityService customerActivityService,
			IEventPublisher eventPublisher)
		{
			this._activeDirectoryB2CExternalAuthSettings = ActiveDirectoryExternalAuthSettings;
			this._externalAuthenticationService = externalAuthenticationService;
			this._localizationService = localizationService;
			this._optionsCache = optionsCache;
			this._permissionService = permissionService;
			this._settingService = settingService;
			this._customerService = customerService;
			this._customerRegistrationService = customerRegistrationService;
			this._customerSettings = customerSettings;
			this._storeContext = storeContext;
			this._genericAttributeService = genericAttributeService;
			this._authenticationService = authenticationService;
			this._providerService = serviceProviderService;

			this._workContext = workContext;
			this._customerActivityService = customerActivityService;
			this._storeInformationSettings = storeInformationSettings;
			this._eventPublisher = eventPublisher;
		}

		#endregion

		#region Methods

		#region Administration
		[AuthorizeAdmin]
		[Area(AreaNames.Admin)]
		public IActionResult Configure()
		{
			if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
				return AccessDeniedView();

			var model = new ConfigurationModel
			{
				Instance = _activeDirectoryB2CExternalAuthSettings.Instance,
				Domain = _activeDirectoryB2CExternalAuthSettings.Domain,
				ClientId = _activeDirectoryB2CExternalAuthSettings.ClientId,
				ClientSecret = _activeDirectoryB2CExternalAuthSettings.ClientSecret,
				CallbackPath = _activeDirectoryB2CExternalAuthSettings.CallbackPath,
				SignUpSignInPolicyId = _activeDirectoryB2CExternalAuthSettings.SignUpSignInPolicyId,
				ResetPasswordPolicyId = _activeDirectoryB2CExternalAuthSettings.ResetPasswordPolicyId,
				EditProfilePolicyId = _activeDirectoryB2CExternalAuthSettings.EditProfilePolicyId
			};

			return View("~/Plugins/ExternalAuth.ActiveDirectoryB2C/Views/Configure.cshtml", model);
		}

		[HttpPost]
		[AdminAntiForgery]
		[AuthorizeAdmin]
		[Area(AreaNames.Admin)]
		public IActionResult Configure(ConfigurationModel model)
		{
			if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
				return AccessDeniedView();

			if (!ModelState.IsValid)
				return Configure();

			//save settings
			_activeDirectoryB2CExternalAuthSettings.Instance = model.Instance;
			_activeDirectoryB2CExternalAuthSettings.Domain = model.Domain;
			_activeDirectoryB2CExternalAuthSettings.ClientId = model.ClientId;
			_activeDirectoryB2CExternalAuthSettings.ClientSecret = model.ClientSecret;
			_activeDirectoryB2CExternalAuthSettings.CallbackPath = model.CallbackPath;
			_activeDirectoryB2CExternalAuthSettings.SignUpSignInPolicyId = model.SignUpSignInPolicyId;
			_activeDirectoryB2CExternalAuthSettings.ResetPasswordPolicyId = model.ResetPasswordPolicyId;
			_activeDirectoryB2CExternalAuthSettings.EditProfilePolicyId = model.EditProfilePolicyId;

			_settingService.SaveSetting(_activeDirectoryB2CExternalAuthSettings);

			//clear ActiveDirectory authentication options cache
			_optionsCache.TryRemove(AzureADB2CDefaults.AuthenticationScheme);

			SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

			return Configure();
		}
		#endregion

		#region Members
		[HttpGet("signup-member")]
		public IActionResult SignUpMember(string returnUrl)
		{
			if (User.Identity.IsAuthenticated) return RedirectToAction("Logout", new { returnUrl = Url.Action("Index", "Home") });
			CheckAzureB2CConfiguration();

			//configure login callback action
			var authenticationProperties = new AuthenticationProperties()
			{
				RedirectUri = Url.Action("MemberCallback", new { returnUrl }),
			};

			return Challenge(authenticationProperties, AzureADB2CDefaults.AuthenticationScheme);
		}

		[HttpGet("login-member")]
		public IActionResult LoginMember(string returnUrl)
		{
			if (User.Identity.IsAuthenticated) return RedirectToAction("Logout", new { returnUrl = Url.Action("Index", "Home") });
			CheckAzureB2CConfiguration();

			//configure login callback action
			var authenticationProperties = new AuthenticationProperties()
			{
				RedirectUri = Url.Action("MemberCallback", new { returnUrl }),
			};

			return Challenge(authenticationProperties, AzureADB2CDefaults.AuthenticationScheme);
		}

		public async Task<IActionResult> MemberCallback(string returnUrl, bool redirected = false)
		{
			var customer = _workContext.CurrentCustomer;
			if (User.Identity.IsAuthenticated)
			{
				if (!customer.IsInCustomerRole(ExtendedCustomerDefaults.MembersRoleName))
				{
					var role = _customerService.GetCustomerRoleBySystemName(ExtendedCustomerDefaults.MembersRoleName);

					customer.CustomerCustomerRoleMappings.Add(new CustomerCustomerRoleMapping() { CustomerRole = role });
					_customerService.UpdateCustomer(customer);
				}
			}
			else
			{
				var authenticationParameters = await CreateExternalAuthenticationParameters();
				if (authenticationParameters != null)
				{
					if (!redirected)
					{
						AssociateExternalAccountWithUserIfNeeded(authenticationParameters, ExtendedCustomerDefaults.MembersRoleName);

						//authenticate Nop user
						_externalAuthenticationService.Authenticate(authenticationParameters, returnUrl);
						return RedirectToAction("MemberCallback", new { returnUrl, redirected = true });
					}
					else
					{
						return SignOutFromADB2C();
					}
				}
			}

			if (customer.IsInCustomerRole(NopCustomerDefaults.AdministratorsRoleName))
			{
				return Redirect("/administration/categories");
			}

			return Redirect("/app/customer/configure-profile");
		}
		#endregion

		#region Providers
		[HttpGet("signup-provider")]
		public IActionResult SignUpProvider(string returnUrl)
		{
			if (User.Identity.IsAuthenticated) return RedirectToAction("Logout", new { returnUrl = Url.Action("Provider", "Home") });
			CheckAzureB2CConfiguration();

			//configure login callback action
			var authenticationProperties = new AuthenticationProperties
			{
				RedirectUri = Url.Action("ProviderCallback", new { returnUrl })
			};

			return Challenge(authenticationProperties, AzureADB2CDefaults.AuthenticationScheme);
		}

		[HttpGet("login-provider")]
		public IActionResult LoginProvider(string returnUrl)
		{
			if(User.Identity.IsAuthenticated) return RedirectToAction("Logout", new { returnUrl = Url.Action("Provider","Home") });
			CheckAzureB2CConfiguration();

			//configure login callback action
			var authenticationProperties = new AuthenticationProperties
			{
				RedirectUri = Url.Action("ProviderCallback", new { returnUrl })
			};

			return Challenge(authenticationProperties, AzureADB2CDefaults.AuthenticationScheme);
		}

		public async Task<IActionResult> ProviderCallback(string returnUrl, bool redirected = false)
		{
			var customer = _workContext.CurrentCustomer;
			if (User.Identity.IsAuthenticated)
			{
				if (!customer.IsInCustomerRole(ExtendedCustomerDefaults.ProvidersRoleName))
				{
					var provider = new Provider
					{
						Website = string.Empty,
						Customer = customer,
						CustomerId = customer.Id,
						Email = customer.Email
					};
					try
					{
						var isCustomerPhoneVerified = _genericAttributeService.GetAttribute<bool>(customer, ExtendedCustomerDefaults.PhoneVerifiedAttribute);
						if (isCustomerPhoneVerified)
						{
							var phoneNumber = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.PhoneAttribute);
							provider.PhoneNumber = phoneNumber;
							provider.Progress = provider.Progress | ProviderAccountProgress.PHONE_CONFIRMATION;
						}
					}
					catch {}
					

					_providerService.InsertProvider(provider);

					var role = _customerService.GetCustomerRoleBySystemName(ExtendedCustomerDefaults.ProvidersRoleName);
					customer.CustomerCustomerRoleMappings.Add(new CustomerCustomerRoleMapping() { CustomerRole = role });
					_customerService.UpdateCustomer(customer);
				}
			}
			else
			{
				var authenticationParameters = await CreateExternalAuthenticationParameters();
				if (authenticationParameters != null)
				{
					if (!redirected)
					{
						AssociateExternalAccountWithUserIfNeeded(authenticationParameters, ExtendedCustomerDefaults.ProvidersRoleName);
						//authenticate Nop user
						_externalAuthenticationService.Authenticate(authenticationParameters, returnUrl);
						return RedirectToAction("ProviderCallback", new { returnUrl, redirected = true });
					}
					else
					{
						return SignOutFromADB2C();
					}
				}
			}

			if (customer.IsInCustomerRole(NopCustomerDefaults.AdministratorsRoleName))
			{
				return Redirect("/administration/categories");
			}

			return Redirect("/app/provider/account");
		}
		#endregion

		[HttpGet("logout")]
		public IActionResult Logout(string returnUrl = null)
		{
			if (User.Identity.IsAuthenticated)
			{
				_authenticationService.SignOut();
				return SignOutFromADB2C(returnUrl);
			}

			return Redirect(returnUrl ?? Url.Action("Index", "Home"));
		}

		private async Task<ExternalAuthenticationParameters> CreateExternalAuthenticationParameters()
		{
			//authenticate ActiveDirectory user
			var authenticateResult = await this.HttpContext.AuthenticateAsync(AzureADB2CDefaults.AuthenticationScheme);
			if (!authenticateResult.Succeeded || !authenticateResult.Principal.Claims.Any()) return null;

			var emails = authenticateResult.Principal.FindFirst(claim => claim.Type == ActiveDirectoryB2CClaimTypes.Emails)?.Value;//TODO:get first email

			//create external authentication parameters
			return new ExternalAuthenticationParameters
			{
				ProviderSystemName = ActiveDirectoryB2CAuthenticationDefaults.ProviderSystemName,
				AccessToken = await this.HttpContext.GetTokenAsync(AzureADB2CDefaults.AuthenticationScheme, "access_token"),
				Email = emails,
				ExternalIdentifier = authenticateResult.Principal.FindFirst(claim => claim.Type == ActiveDirectoryB2CClaimTypes.ObjectIdentifier)?.Value,
				ExternalDisplayIdentifier = authenticateResult.Principal.FindFirst(claim => claim.Type == ActiveDirectoryB2CClaimTypes.FullName)?.Value,
				Claims = authenticateResult.Principal.Claims.Select(claim => new ExternalAuthenticationClaim(claim.Type, claim.Value)).ToList()
			};
		}


		private void AssociateExternalAccountWithUserIfNeeded(ExternalAuthenticationParameters authenticationParameters, string roleName)
		{
			if (!string.IsNullOrEmpty(authenticationParameters.Email))
			{
				var customer = _customerService.GetCustomerByEmail(authenticationParameters.Email);

				if (customer != null && customer.IsInCustomerRole(roleName))
				{
					var externalCustomer = _externalAuthenticationService.GetUserByExternalAuthenticationParameters(authenticationParameters);

					if (externalCustomer == null || !externalCustomer.ExternalAuthenticationRecords.Any(r => r.ExternalIdentifier == authenticationParameters.ExternalIdentifier))
					{
						_externalAuthenticationService.AssociateExternalAccountWithUser(customer, authenticationParameters);
					}
				}
			}
		}

		private void CheckAzureB2CConfiguration()
		{
			if (!_externalAuthenticationService.ExternalAuthenticationMethodIsAvailable(ActiveDirectoryB2CAuthenticationDefaults.ProviderSystemName))
				throw new NopException("ActiveDirectoryB2C authentication module cannot be loaded");

			if (string.IsNullOrEmpty(_activeDirectoryB2CExternalAuthSettings.Instance)
				|| string.IsNullOrEmpty(_activeDirectoryB2CExternalAuthSettings.Domain)
				|| string.IsNullOrEmpty(_activeDirectoryB2CExternalAuthSettings.ClientId)
				|| string.IsNullOrEmpty(_activeDirectoryB2CExternalAuthSettings.CallbackPath))
				throw new NopException("ActiveDirectoryB2C authentication module not configured");
		}

		private SignOutResult SignOutFromADB2C(string returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Action("Index", "Home");

			var authenticationProperties = new AuthenticationProperties()
			{
				RedirectUri = returnUrl
			};

			return SignOut(authenticationProperties, new string[] { AzureADB2CDefaults.CookieScheme, AzureADB2CDefaults.OpenIdScheme });
		}

		#endregion
	}
}