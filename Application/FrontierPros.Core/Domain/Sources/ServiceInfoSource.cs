using FrontierPros.Core.Domain.Catalog;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Sources
{
	public class ServiceInfoSource : BaseEntity
	{
		private ICollection<ServiceInfoSourceAndNameTokenSource> _nameTokens;
		private ICollection<ServiceCategorySourceAndServiceInfoSource> _serviceCategorySources;

		public string PK { get; set; }
		public string IDString { get; set; }
		public string Name { get; set; }
		public string Taxonym { get; set; }
		public string PluralTaxonym { get; set; }
		public double Popularity { get; set; }
		public double Rank { get; set; }

		public bool Deleted { get; set; }
		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }

		public bool Published { get; set; }
		public SourceType SourceType { get; set; }

		public virtual ICollection<ServiceInfoSourceAndNameTokenSource> NameTokens
		{
			get => _nameTokens ?? (_nameTokens = new List<ServiceInfoSourceAndNameTokenSource>());
			protected set => _nameTokens = value;
		}

		public virtual ICollection<ServiceCategorySourceAndServiceInfoSource> ServiceCategorySources
		{
			get => _serviceCategorySources ?? (_serviceCategorySources = new List<ServiceCategorySourceAndServiceInfoSource>());
			protected set => _serviceCategorySources = value;
		}
	}
}
