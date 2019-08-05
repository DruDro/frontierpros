using Nop.Core.Configuration;

namespace Nop.Plugin.ExternalAuth.Twitter
{
    /// <summary>
    /// Represents settings of the Twitter authentication method
    /// </summary>
    public class TwitterExternalAuthSettings : ISettings
    {
        /// <summary>
        /// Gets or sets OAuth2 client identifier
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets OAuth2 client secret
        /// </summary>
        public string ConsumerSecret { get; set; }
    }
}
