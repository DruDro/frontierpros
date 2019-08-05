using FrontierPros.Core.Domain.ServiceProviders;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Providers
{
	public class ProviderAndServiceProvider : BaseEntity
	{
		public int ProviderId { get; set; }
		public virtual Provider Provider { get; set; }

		public int ServiceProviderId { get; set; }
		public virtual ServiceProvider ServiceProvider { get; set; }
	}
}
