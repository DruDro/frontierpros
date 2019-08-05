using FrontierPros.Core.Domain.Questions;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Sources
{
	public class AddonSource : BaseEntity
	{
		private ICollection<AddonItemSource> _addonItems;

		public string Name { get; set; }
		public int ServiceInfoSourceId { get; set; }
		public virtual ServiceInfoSource ServiceInfo { get; set; }

		public virtual ICollection<AddonItemSource> AddonItems
		{
			get => _addonItems ?? (_addonItems = new List<AddonItemSource>());
			protected set => _addonItems = value;
		}
	}
}
