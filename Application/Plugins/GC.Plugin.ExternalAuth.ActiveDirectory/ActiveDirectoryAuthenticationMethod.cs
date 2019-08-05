using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory
{
    /// <summary>
    /// Represents method for the authentication with Active Directory
    /// </summary>
    public class ActiveDirectoryAuthenticationMethod : BasePlugin, IExternalAuthenticationMethod
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public ActiveDirectoryAuthenticationMethod(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ActiveDirectoryAuthentication/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return ActiveDirectoryAuthenticationDefaults.ViewComponentName;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new ActiveDirectoryExternalAuthSettings());

			//locales
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Instance", "Instance");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Instance.Hint", "Enter your Instance here. You can find it on your ActiveDirectory application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Domain", "Domain");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Domain.Hint", "Enter your Domain here. You can find it on your ActiveDirectory application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.TenantId", "Tenant Id");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.TenantId.Hint", "Enter your Tenant Id here. You can find it on your ActiveDirectory application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.ClientId", "Client Id");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.ClientId.Hint", "Enter your Client Id here. You can find it on your ActiveDirectory application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.CallbackPath", "Callback Path");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.CallbackPath.Hint", "Enter your Callback Path here. You can find it on your ActiveDirectory application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Instructions", "TODO:Add instructions");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ActiveDirectoryExternalAuthSettings>();

			//locales
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Instance");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Instance.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Domain");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Domain.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.TenantId");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.TenantId.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.ClientId");
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.ClientId.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.CallbackPath");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.CallbackPath.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectory.Instructions");

            base.Uninstall();
        }

        #endregion
    }
}