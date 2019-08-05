using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Services.Authentication.External;

namespace Nop.Plugin.ExternalAuth.Twitter.Infrastructure
{
    /// <summary>
    /// Registration of Twitter authentication service (plugin)
    /// </summary>
    public class TwitterAuthenticationRegistrar : IExternalAuthenticationRegistrar
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">Authentication builder</param>
        public void Configure(AuthenticationBuilder builder)
        {
            builder.AddTwitter(TwitterDefaults.AuthenticationScheme, options =>
            {
                var settings = EngineContext.Current.Resolve<TwitterExternalAuthSettings>();

                options.ConsumerKey = settings.ConsumerKey;
                options.ConsumerSecret = settings.ConsumerSecret;
                options.SaveTokens = true;
				options.RetrieveUserDetails = true;
            });
        }
    }
}
