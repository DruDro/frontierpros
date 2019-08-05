using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Catalog
{
	public enum SourceType
	{
		FrontierPros,
		Thumbtack,
		VConnect
	}

	public class ServiceInfo : BaseEntity
	{
		private ICollection<ServiceInfoAndNameToken> _nameTokens;
		private ICollection<ServiceCategoryAndServiceInfo> _serviceCategories;

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

		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public virtual ICollection<ServiceInfoAndNameToken> NameTokens
		{
			get => _nameTokens ?? (_nameTokens = new List<ServiceInfoAndNameToken>());
			protected set => _nameTokens = value;
		}

		public virtual ICollection<ServiceCategoryAndServiceInfo> ServiceCategories
		{
			get => _serviceCategories ?? (_serviceCategories = new List<ServiceCategoryAndServiceInfo>());
			protected set => _serviceCategories = value;
		}
	}
}
