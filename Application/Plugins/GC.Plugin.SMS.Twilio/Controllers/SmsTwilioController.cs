using System;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Sms.Twilio.Models;
using Nop.Plugin.SMS.Twilio;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Sms.Twilio.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class SmsTwilioController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IPluginFinder _pluginFinder;
        private readonly ISettingService _settingService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public SmsTwilioController(ILocalizationService localizationService,
            IPermissionService permissionService,
            IPluginFinder pluginFinder,
            ISettingService settingService,
            IStoreContext storeContext,
            IStoreService storeService)

        {
            this._localizationService = localizationService;
            this._permissionService = permissionService;
            this._pluginFinder = pluginFinder;
            this._settingService = settingService;
            this._storeContext = storeContext;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var TwilioSettings = _settingService.LoadSetting<TwilioSettings>();

            var model = new SmsTwilioModel
            {
                Enabled = TwilioSettings.Enabled,
                AuthToken = TwilioSettings.AuthToken,
                AccountSid = TwilioSettings.AccountSid,
                PhoneNumber = TwilioSettings.PhoneNumber,
            };

            return View("~/Plugins/SMS.Twilio/Views/Configure.cshtml", model);
        }


        [HttpPost, ActionName("Configure")]
        [FormValueRequired("save")]
        public IActionResult Configure(SmsTwilioModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            //load settings for a chosen store scope
            var TwilioSettings = _settingService.LoadSetting<TwilioSettings>();

            //save settings
            TwilioSettings.Enabled = model.Enabled;
            TwilioSettings.AccountSid = model.AccountSid;
            TwilioSettings.AuthToken = model.AuthToken;
            TwilioSettings.PhoneNumber = model.PhoneNumber;

			/* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
			_settingService.SaveSetting(TwilioSettings, x => x.Enabled, 0, false);
			_settingService.SaveSetting(TwilioSettings, x => x.AccountSid, 0, false);
            _settingService.SaveSetting(TwilioSettings, x => x.AuthToken, 0, false);
			_settingService.SaveSetting(TwilioSettings, x => x.PhoneNumber, 0, false);

            //now clear settings cache
            _settingService.ClearCache();

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        [HttpPost, ActionName("Configure")]
        [FormValueRequired("test")]
        public IActionResult TestSms(SmsTwilioModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName("Mobile.SMS.Twilio");
            if (pluginDescriptor == null)
                throw new Exception("Cannot load the plugin");

            var plugin = pluginDescriptor.Instance() as TwilioSmsProvider;
            if (plugin == null)
                throw new Exception("Cannot load the plugin");

            //load settings for a chosen store scope
            var TwilioSettings = _settingService.LoadSetting<TwilioSettings>();

            //test SMS send
            if (plugin.SendSms(model.TestPhoneNumber, model.TestMessage, TwilioSettings))
                SuccessNotification(_localizationService.GetResource("Plugins.Sms.Twilio.TestSuccess"));
            else
                ErrorNotification(_localizationService.GetResource("Plugins.Sms.Twilio.TestFailed"));

            return Configure();
        }

        #endregion
    }
}