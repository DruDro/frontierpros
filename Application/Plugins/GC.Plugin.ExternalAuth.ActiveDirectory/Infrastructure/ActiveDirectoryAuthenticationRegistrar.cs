using Microsoft.AspNetCore.Authentication;
using Nop.Core.Infrastructure;
using Nop.Services.Authentication.External;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory.Infrastructure
{
    /// <summary>
    /// Registration of ActiveDirectory authentication service (plugin)
    /// </summary>
    public class ActiveDirectoryAuthenticationRegistrar : IExternalAuthenticationRegistrar
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">Authentication builder</param>
        public void Configure(AuthenticationBuilder builder)
        {
            builder.AddAzureAD(options =>
            {
                var settings = EngineContext.Current.Resolve<ActiveDirectoryExternalAuthSettings>();
				options.Instance = settings.Instance;
				options.Domain = settings.Domain;
				options.TenantId = settings.TenantId;
				options.ClientId = settings.ClientId;
				options.CallbackPath = settings.CallbackPath;
			});
        }
    }
}
