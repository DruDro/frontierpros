using FrontierPros.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Services
{
	public class ServiceItemMap : NopEntityTypeConfiguration<ServiceItem>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceItem> builder)
		{
			builder.ToTable(nameof(ServiceItem));
			builder.HasKey(serviceItem => serviceItem.Id);

			builder.HasOne(serviceItem => serviceItem.ServiceInfo)
				.WithMany()
				.HasForeignKey(serviceItem => serviceItem.ServiceInfoId);

			builder.HasOne(serviceItem => serviceItem.Icon)
				.WithMany()
				.HasForeignKey(serviceItem => serviceItem.IconId);

			builder.HasOne(serviceItem => serviceItem.Product)
				.WithMany()
				.HasForeignKey(serviceItem => serviceItem.ProductId)
				.IsRequired();

			builder.HasOne(serviceItem => serviceItem.Provider)
				.WithMany(provider => provider.Services)
				.HasForeignKey(serviceItem => serviceItem.ProviderId)
				.IsRequired();

			builder.HasOne(serviceItem => serviceItem.TimeZoneData)
				.WithMany()
				.HasForeignKey(serviceItem => serviceItem.TimeZoneDataId);

			builder.Property(serviceItem => serviceItem.BasePrice).HasColumnType("decimal(18, 4)");

			base.Configure(builder);
		}
		#endregion
	}
}
