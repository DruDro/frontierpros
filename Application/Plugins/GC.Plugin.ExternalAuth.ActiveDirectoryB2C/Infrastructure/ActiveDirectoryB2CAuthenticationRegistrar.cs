using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Nop.Core.Infrastructure;
using Nop.Services.Authentication.External;

namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C.Infrastructure
{
    /// <summary>
    /// Registration of ActiveDirectoryB2C authentication service (plugin)
    /// </summary>
    public class ActiveDirectoryB2CAuthenticationRegistrar : IExternalAuthenticationRegistrar
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">Authentication builder</param>
        public void Configure(AuthenticationBuilder builder)
        {
			builder.AddAzureADB2C(
				AzureADB2CDefaults.AuthenticationScheme, 
				AzureADB2CDefaults.OpenIdScheme, 
				AzureADB2CDefaults.CookieScheme, 
				AzureADB2CDefaults.DisplayName,  
				options => {
					var settings = EngineContext.Current.Resolve<ActiveDirectoryB2CExternalAuthSettings>();
					options.Instance = settings.Instance;
					options.Domain = settings.Domain;
					options.ClientId = settings.ClientId;
					options.ClientSecret = settings.ClientSecret;
					options.CallbackPath = settings.CallbackPath;
					options.SignUpSignInPolicyId = settings.SignUpSignInPolicyId;
					options.ResetPasswordPolicyId = settings.ResetPasswordPolicyId;
					options.EditProfilePolicyId = settings.EditProfilePolicyId;
			});
		}
    }
}
