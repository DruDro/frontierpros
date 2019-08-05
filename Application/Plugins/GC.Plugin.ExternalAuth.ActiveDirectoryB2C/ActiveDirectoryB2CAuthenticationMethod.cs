using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C
{
	/// <summary>
	/// Represents method for the authentication with Active Directory B2C
	/// </summary>
	public class ActiveDirectoryB2CAuthenticationMethod : BasePlugin, IExternalAuthenticationMethod
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public ActiveDirectoryB2CAuthenticationMethod(ILocalizationService localizationService,
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
            return $"{_webHelper.GetStoreLocation()}Admin/ActiveDirectoryB2CAuthentication/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return ActiveDirectoryB2CAuthenticationDefaults.ViewComponentName;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new ActiveDirectoryB2CExternalAuthSettings());

			//locales
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Instance", "Instance");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Instance.Hint", "Enter your Instance here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Domain", "Domain");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Domain.Hint", "Enter your Domain here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientId", "Client Id");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientId.Hint", "Enter your Client Id here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientSecret", "Client Secret");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientSecret.Hint", "Enter your Client Secret here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.CallbackPath", "Callback Path");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.CallbackPath.Hint", "Enter your Callback Path here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.SignUpSignInPolicyId", "SignUpSignInPolicyId");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.SignUpSignInPolicyId.Hint", "Enter your SignUpSignInPolicyId here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ResetPasswordPolicyId", "ResetPasswordPolicyId");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ResetPasswordPolicyId.Hint", "Enter your ResetPasswordPolicyId here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.EditProfilePolicyId", "EditProfilePolicyId");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.EditProfilePolicyId.Hint", "Enter your EditProfilePolicyId here. You can find it on your Active Directory B2C application page.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Instructions", "TODO:Add instructions");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ActiveDirectoryB2CExternalAuthSettings>();

			//locales
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Instance");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Instance.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Domain");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Domain.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientId");
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientId.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientSecret");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientSecret.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.CallbackPath");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.CallbackPath.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.SignUpSignInPolicyId");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.SignUpSignInPolicyId.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ResetPasswordPolicyId");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.ResetPasswordPolicyId.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.EditProfilePolicyId");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.EditProfilePolicyId.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.ActiveDirectoryB2C.Instructions");

            base.Uninstall();
        }

        #endregion
    }
}