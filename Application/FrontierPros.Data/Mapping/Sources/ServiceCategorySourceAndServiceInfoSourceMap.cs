using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class ServiceCategorySourceAndServiceInfoSourceMap : NopEntityTypeConfiguration<ServiceCategorySourceAndServiceInfoSource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceCategorySourceAndServiceInfoSource> builder)
		{
			builder.ToTable(nameof(ServiceCategorySourceAndServiceInfoSource));
			builder.HasKey(serviceCategory => serviceCategory.Id);

			builder.HasOne(serviceCategory => serviceCategory.ServiceInfo)
				.WithMany(categoryInfoSource=>categoryInfoSource.ServiceCategorySources)
				.HasForeignKey(serviceCategory => serviceCategory.ServiceInfoSourceId)
				.IsRequired();

			builder.HasOne(serviceCategory => serviceCategory.ServiceCategory)
				.WithMany(serviceCategory => serviceCategory.ServiceSources)
				.HasForeignKey(categoryGroup => categoryGroup.ServiceCategorySourceId)
				.IsRequired();

			base.Configure(builder);
		}

		#endregion
	}
}
