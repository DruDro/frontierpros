using System;
using System.Linq;
using System.ServiceModel;
using FrontierPros.Services.Customers;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Nop.Plugin.SMS.Twilio
{
    /// <summary>
    /// Represents the Twilio SMS provider
    /// </summary>
    public class TwilioSmsProvider : BasePlugin, IMiscPlugin
    {
        #region Fields

        private readonly TwilioSettings _twilioSettings;
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        private readonly ISmsProviderService _smsProviderService;

        #endregion

        #region Ctor

        public TwilioSmsProvider(TwilioSettings TwilioSettings,
            ILogger logger,
            ISettingService settingService,
            IWebHelper webHelper,
            ILocalizationService localizationService,
            ISmsProviderService smsProviderService)
        {
            this._twilioSettings = TwilioSettings;
            this._logger = logger;
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._localizationService = localizationService;
            this._smsProviderService = smsProviderService;
        }

		#endregion

		#region Methods

		/// <summary>
		/// Send SMS 
		/// </summary>
		/// <param name="text">Phone Number</param>
		/// <param name="text">Text</param>
		/// <param name="settings">Twilio settings</param>
		/// <returns>True if SMS was successfully sent; otherwise false</returns>
		public bool SendSms(string phoneNumber, string text, TwilioSettings settings = null)
        {
            return _smsProviderService.SendSms(phoneNumber, text, settings);
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/SmsTwilio/Configure";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new TwilioSettings());

            //locales
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.Enabled", "Enabled");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.Enabled.Hint", "Check to enable SMS provider.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.AccountSid", "AccountSid");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.AccountSid.Hint", "Specify AccountSid for Twilio API.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.AuthToken", "AuthToken");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.AuthToken.Hint", "Specify AuthToken for Twilio API.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.PhoneNumber", "Phone number");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.PhoneNumber.Hint", "Enter your phone number.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestPhoneNumber", "Test Phone Number");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestPhoneNumber.Hint", "Enter test phone number.");
			_localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestMessage", "Message text");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestMessage.Hint", "Enter text of the test message.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.SendTest", "Send");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.SendTest.Hint", "Send test message");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.TestFailed", "Test message sending failed");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Sms.Twilio.TestSuccess", "Test message was sent");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<TwilioSettings>();

			//locales
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.Enabled");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.Enabled.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.AccountSid");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.AccountSid.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.AuthToken");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.AuthToken.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.PhoneNumber");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.PhoneNumber.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestPhoneNumber");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestPhoneNumber.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestMessage");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.Fields.TestMessage.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.SendTest");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.SendTest.Hint");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.TestFailed");
			_localizationService.DeletePluginLocaleResource("Plugins.Sms.Twilio.TestSuccess");

            base.Uninstall();
        }

        #endregion
    }
}
