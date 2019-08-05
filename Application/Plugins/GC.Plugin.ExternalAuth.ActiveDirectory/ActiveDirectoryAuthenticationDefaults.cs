
namespace Nop.Plugin.ExternalAuth.ActiveDirectory
{
    /// <summary>
    /// Default values used by the ActiveDirectory authentication middleware
    /// </summary>
    public class ActiveDirectoryAuthenticationDefaults
	{
        /// <summary>
        /// System name of the external authentication method
        /// </summary>
        public const string ProviderSystemName = "ExternalAuth.ActiveDirectory";

        /// <summary>
        /// Name of the view component to display plugin in public store
        /// </summary>
        public const string ViewComponentName = "ActiveDirectoryAuthentication";
    }
}