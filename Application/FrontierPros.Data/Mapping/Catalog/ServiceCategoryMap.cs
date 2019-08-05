using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Catalog
{
	public partial class ServiceCategoryMap : NopEntityTypeConfiguration<ServiceCategory>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceCategory> builder)
		{
			builder.ToTable(nameof(ServiceCategory));
			builder.HasKey(serviceCategory => serviceCategory.Id);

			base.Configure(builder);
		}
		#endregion
	}
}
