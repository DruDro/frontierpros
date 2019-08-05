using FrontierPros.Core.Domain.Catalog;
using Nop.Core;
using Nop.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.ServiceProviders
{
	public class ServiceProvider : BaseEntity
	{
		public string Name { get; set; }
		public string Email { get; set; }

		public bool Active { get; set; }
		public bool Deleted { get; set; }

		public int VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }
	}
}
