
namespace Nop.Plugin.ExternalAuth.Twitter
{
    /// <summary>
    /// Default values used by the Twitter authentication middleware
    /// </summary>
    public class TwitterAuthenticationDefaults
    {
        /// <summary>
        /// System name of the external authentication method
        /// </summary>
        public const string ProviderSystemName = "ExternalAuth.Twitter";

        /// <summary>
        /// Name of the view component to display plugin in public store
        /// </summary>
        public const string ViewComponentName = "TwitterAuthentication";
    }
}