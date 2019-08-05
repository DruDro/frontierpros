using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Catalog
{
	public class ServiceCategory : BaseEntity
	{
		private ICollection<ServiceCategoryAndServiceInfo> _services;

		public string Name { get; set; }
		public bool Published { get; set; }
		public SourceType SourceType { get; set; }

		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }

		public virtual ICollection<ServiceCategoryAndServiceInfo> Services
		{
			get => _services ?? (_services = new List<ServiceCategoryAndServiceInfo>());
			protected set => _services = value;
		}
	}
}
