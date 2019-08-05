using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Configuration
{
	public class ADB2CGraphConfig
	{
		public string Instance { get; set; }
		public string GraphResourceId { get; set; }
		public string GraphEndpoint { get; set; }
		public string GraphSuffix { get; set; }
		public string GraphVersion { get; set; }

		public string Tenant { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
	}
}
