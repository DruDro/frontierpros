using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.ExternalAuth.Twitter
{
    /// <summary>
    /// Represents method for the authentication with Twitter account
    /// </summary>
    public class TwitterAuthenticationMethod : BasePlugin, IExternalAuthenticationMethod
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public TwitterAuthenticationMethod(ILocalizationService localizationService,
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
            return $"{_webHelper.GetStoreLocation()}Admin/TwitterAuthentication/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return TwitterAuthenticationDefaults.ViewComponentName;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new TwitterExternalAuthSettings());

            //locales
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerKey", "Consumer Key");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerKey.Hint", "Enter your Consumer Key here. You can find it on your Twitter application page.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerSecret", "Consumer Secret");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerSecret.Hint", "Enter your Consumer Secret here. You can find it on your Twitter application page.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.ExternalAuth.Twitter.Instructions", "TODO:Add instructions");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<TwitterExternalAuthSettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerKey");
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerKey.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerSecret");
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.Twitter.ConsumerSecret.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.ExternalAuth.Twitter.Instructions");

            base.Uninstall();
        }

        #endregion
    }
}