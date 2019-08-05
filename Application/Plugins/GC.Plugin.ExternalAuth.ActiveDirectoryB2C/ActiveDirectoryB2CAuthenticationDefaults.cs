
namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C
{
    /// <summary>
    /// Default values used by the ActiveDirectory authentication middleware
    /// </summary>
    public class ActiveDirectoryB2CAuthenticationDefaults
	{
        /// <summary>
        /// System name of the external authentication method
        /// </summary>
        public const string ProviderSystemName = "ExternalAuth.ActiveDirectoryB2C";

        /// <summary>
        /// Name of the view component to display plugin in public store
        /// </summary>
        public const string ViewComponentName = "ActiveDirectoryB2CAuthentication";
    }
}