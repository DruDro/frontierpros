using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Catalog
{
	public partial class ServiceCategoryAndServiceInfoMap : NopEntityTypeConfiguration<ServiceCategoryAndServiceInfo>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceCategoryAndServiceInfo> builder)
		{
			builder.ToTable(nameof(ServiceCategoryAndServiceInfo));
			builder.HasKey(serviceCategoryAndServiceInfo => serviceCategoryAndServiceInfo.Id);

			builder.HasOne(serviceCategoryAndServiceInfo => serviceCategoryAndServiceInfo.ServiceInfo)
				.WithMany(serviceInfo => serviceInfo.ServiceCategories)
				.HasForeignKey(serviceCategoryAndServiceInfo => serviceCategoryAndServiceInfo.ServiceInfoId)
				.IsRequired();

			builder.HasOne(serviceCategoryAndServiceInfo => serviceCategoryAndServiceInfo.ServiceCategory)
				.WithMany(serviceCategory => serviceCategory.Services)
				.HasForeignKey(serviceCategoryAndServiceInfo => serviceCategoryAndServiceInfo.ServiceCategoryId)
				.IsRequired();

			base.Configure(builder);
		}

		#endregion
	}
}
