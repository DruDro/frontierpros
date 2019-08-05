using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Sms.Twilio.Models
{
    public class SmsTwilioModel
    {
        [NopResourceDisplayName("Plugins.Sms.Twilio.Fields.Enabled")]
        public bool Enabled { get; set; }

        [NopResourceDisplayName("Plugins.Sms.Twilio.Fields.AccountSid")]
        public string AccountSid { get; set; }

        [NopResourceDisplayName("Plugins.Sms.Twilio.Fields.AuthToken")]
        public string AuthToken { get; set; }

        [NopResourceDisplayName("Plugins.Sms.Twilio.Fields.PhoneNumber")]
        public string PhoneNumber { get; set; }

        [NopResourceDisplayName("Plugins.Sms.Twilio.Fields.TestMessage")]
        public string TestMessage { get; set; }

		[NopResourceDisplayName("Plugins.Sms.Twilio.Fields.TestPhoneNumber")]
		public string TestPhoneNumber { get; set; }
	}
}