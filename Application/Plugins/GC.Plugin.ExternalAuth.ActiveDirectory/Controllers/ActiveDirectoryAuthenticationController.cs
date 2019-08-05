using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nop.Core;
using Nop.Plugin.ExternalAuth.ActiveDirectory.Models;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory.Controllers
{
    public class ActiveDirectoryAuthenticationController : BasePluginController
    {
        #region Fields

        private readonly ActiveDirectoryExternalAuthSettings _activeDirectoryExternalAuthSettings;
        private readonly IExternalAuthenticationService _externalAuthenticationService;
        private readonly ILocalizationService _localizationService;
        private readonly IOptionsMonitorCache<AzureADOptions> _optionsCache;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public ActiveDirectoryAuthenticationController(ActiveDirectoryExternalAuthSettings ActiveDirectoryExternalAuthSettings,
            IExternalAuthenticationService externalAuthenticationService,
            ILocalizationService localizationService,
            IOptionsMonitorCache<AzureADOptions> optionsCache,
            IPermissionService permissionService,
            ISettingService settingService)
        {
            this._activeDirectoryExternalAuthSettings = ActiveDirectoryExternalAuthSettings;
            this._externalAuthenticationService = externalAuthenticationService;
            this._localizationService = localizationService;
            this._optionsCache = optionsCache;
            this._permissionService = permissionService;
            this._settingService = settingService;
        }

        #endregion

        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
                return AccessDeniedView();

            var model = new ConfigurationModel
            {
				Instance = _activeDirectoryExternalAuthSettings.Instance,
				Domain = _activeDirectoryExternalAuthSettings.Domain,
				TenantId = _activeDirectoryExternalAuthSettings.TenantId,
				ClientId = _activeDirectoryExternalAuthSettings.ClientId,
				CallbackPath = _activeDirectoryExternalAuthSettings.CallbackPath
            };

            return View("~/Plugins/ExternalAuth.ActiveDirectory/Views/Configure.cshtml", model);
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
			_activeDirectoryExternalAuthSettings.Instance = model.Instance;
			_activeDirectoryExternalAuthSettings.Domain = model.Domain;
			_activeDirectoryExternalAuthSettings.TenantId = model.TenantId;
			_activeDirectoryExternalAuthSettings.ClientId = model.ClientId;
			_activeDirectoryExternalAuthSettings.CallbackPath = model.CallbackPath;


			_settingService.SaveSetting(_activeDirectoryExternalAuthSettings);

            //clear ActiveDirectory authentication options cache
            _optionsCache.TryRemove(AzureADDefaults.AuthenticationScheme);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        public IActionResult Login(string returnUrl)
        {
            if (!_externalAuthenticationService.ExternalAuthenticationMethodIsAvailable(ActiveDirectoryAuthenticationDefaults.ProviderSystemName))
                throw new NopException("ActiveDirectory authentication module cannot be loaded");

            if (string.IsNullOrEmpty(_activeDirectoryExternalAuthSettings.Instance)
				|| string.IsNullOrEmpty(_activeDirectoryExternalAuthSettings.Domain) 
				|| string.IsNullOrEmpty(_activeDirectoryExternalAuthSettings.TenantId)
				|| string.IsNullOrEmpty(_activeDirectoryExternalAuthSettings.ClientId)
				|| string.IsNullOrEmpty(_activeDirectoryExternalAuthSettings.CallbackPath))
                throw new NopException("ActiveDirectory authentication module not configured");

            //configure login callback action
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoginCallback", "ActiveDirectoryAuthentication", new { returnUrl = returnUrl })
            };

            return Challenge(authenticationProperties, AzureADDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> LoginCallback(string returnUrl)
        {
            //authenticate ActiveDirectory user
            var authenticateResult =  await this.HttpContext.AuthenticateAsync(AzureADDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded || !authenticateResult.Principal.Claims.Any())
                return RedirectToRoute("Login");

            //create external authentication parameters
            var authenticationParameters = new ExternalAuthenticationParameters
            {
                ProviderSystemName = ActiveDirectoryAuthenticationDefaults.ProviderSystemName,
                AccessToken = await this.HttpContext.GetTokenAsync(AzureADDefaults.AuthenticationScheme, "access_token"),
                Email = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Email)?.Value,
                ExternalIdentifier = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value,
                ExternalDisplayIdentifier = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Name)?.Value,
                Claims = authenticateResult.Principal.Claims.Select(claim => new ExternalAuthenticationClaim(claim.Type, claim.Value)).ToList()
            };

            //authenticate Nop user
            return _externalAuthenticationService.Authenticate(authenticationParameters, returnUrl);
        }

        #endregion
    }
}