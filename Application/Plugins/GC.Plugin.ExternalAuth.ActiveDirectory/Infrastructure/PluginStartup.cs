using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory.Infrastructure
{
	public class PluginStartup : INopStartup
	{
		public void Configure(IApplicationBuilder application)
		{
		}

		public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
			{
				options.Authority = options.Authority + "/v2.0/";
				options.TokenValidationParameters.ValidateIssuer = false;
			});

			//services.AddAuthorization(options =>
			//{
			//	options.AddPolicy("Member", policyBuilder => policyBuilder.RequireClaim("groups", "[enter object id]"));
			//});
		}

		/// <summary>
		/// Gets order of this startup configuration implementation
		/// </summary>
		public int Order
		{
			//authentication should be loaded before MVC
			get { return 501; }
		}
	}
}
