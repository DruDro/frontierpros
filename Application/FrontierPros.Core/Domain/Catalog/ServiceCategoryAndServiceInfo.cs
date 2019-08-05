using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Catalog
{
	public class ServiceCategoryAndServiceInfo : BaseEntity
	{
		public int ServiceInfoId { get; set; }
		public virtual ServiceInfo ServiceInfo { get; set; }

		public int ServiceCategoryId { get; set; }
		public virtual ServiceCategory ServiceCategory { get; set; }
	}
}
