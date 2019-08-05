using FrontierPros.Core.Domain.Providers;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Licenses
{
	public partial class License : BaseEntity
	{
		public string State { get; set; }
		public string LicenseType { get; set; }
		public string LicenseNumber { get; set; }
		public int ProviderId { get; set; }
		public virtual Provider Provider { get; set; }
	}
}
