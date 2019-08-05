using Castle.Core.Logging;
using FrontierPros.Services.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Nop.Plugin.SMS.Twilio.Services
{
    public class TwilioSmsProviderService : ISmsProviderService
    {
        private readonly TwilioSettings _twilioSettings;

        public TwilioSmsProviderService(TwilioSettings twilioSettings)
        {
            this._twilioSettings = twilioSettings;
        }

        /// <summary>
        /// Send SMS 
        /// </summary>
        /// <param name="text">Phone Number</param>
        /// <param name="text">Text</param>
        /// <param name="settings">Twilio settings</param>
        /// <returns>True if SMS was successfully sent; otherwise false</returns>
        public bool SendSms(string phoneNumber, string text, object settings = null)
        {
            var TwilioSettings = settings as TwilioSettings ?? _twilioSettings;
            if (!TwilioSettings.Enabled)
                return false;

            try
            {
                //check credentials
                TwilioClient.Init(TwilioSettings.AccountSid, TwilioSettings.AuthToken);


                var from = new PhoneNumber(TwilioSettings.PhoneNumber);
                var to = new PhoneNumber(phoneNumber);


                //send SMS
                var message = MessageResource.Create(to: to, from: from, body: text);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
