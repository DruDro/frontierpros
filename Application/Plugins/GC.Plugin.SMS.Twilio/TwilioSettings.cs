using Nop.Core.Configuration;

namespace Nop.Plugin.SMS.Twilio
{
    public class TwilioSettings : ISettings
    {
        /// <summary>
        /// Gets or sets the value indicting whether this SMS provider is enabled
        /// </summary>
        public bool Enabled { get; set; }

		/// <summary>
		/// Gets or sets the Twilio AccountSid
		/// </summary>
		public string AccountSid { get; set; }

		/// <summary>
		/// Gets or sets the Twilio AuthToken
		/// </summary>
		public string AuthToken { get; set; }

        /// <summary>
        /// Gets or sets the store owner phone number
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}