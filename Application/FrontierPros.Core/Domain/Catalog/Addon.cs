using FrontierPros.Core.Domain.Questions;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Catalog
{
	public class Addon : BaseEntity
	{
		private ICollection<AddonItem> _addonItems;

		public string Name { get; set; }
		public int ServiceInfoId { get; set; }
		public virtual ServiceInfo ServiceInfo { get; set; }

		public virtual ICollection<AddonItem> AddonItems
		{
			get => _addonItems ?? (_addonItems = new List<AddonItem>());
			protected set => _addonItems = value;
		}
	}
}
