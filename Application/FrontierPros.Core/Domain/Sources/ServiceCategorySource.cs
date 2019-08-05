using FrontierPros.Core.Domain.Catalog;
using Nop.Core;
using System;
using System.Collections.Generic;

namespace FrontierPros.Core.Domain.Sources
{
	public class ServiceCategorySource : BaseEntity
	{
		private ICollection<ServiceCategorySourceAndServiceInfoSource> _serviceSources;

		public string Name { get; set; }
		public bool Published { get; set; }
		public SourceType SourceType { get; set; }

		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }

		public virtual ICollection<ServiceCategorySourceAndServiceInfoSource> ServiceSources
		{
			get => _serviceSources ?? (_serviceSources = new List<ServiceCategorySourceAndServiceInfoSource>());
			protected set => _serviceSources = value;
		}
	}
}
