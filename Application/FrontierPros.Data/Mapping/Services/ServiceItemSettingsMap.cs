using FrontierPros.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Services
{
	public class ServiceItemSettingsMap : NopEntityTypeConfiguration<ServiceItemSettings>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceItemSettings> builder)
		{
			builder.ToTable($"tbl{nameof(ServiceItemSettings)}");

			builder.HasKey(serviceItemConfiguration => serviceItemConfiguration.Id);

			builder.HasOne(serviceItemConfiguration => serviceItemConfiguration.ServiceItem)
				.WithMany(service => service.Settings)
				.HasForeignKey(providerOptionPrice => providerOptionPrice.ServiceItemId)
				.IsRequired();

			builder.HasOne(service => service.Option)
				.WithMany()
				.HasForeignKey(service => service.OptionId)
				.IsRequired();

			builder.Property(providerOptionPrice => providerOptionPrice.Price).HasColumnType("decimal(18, 4)");

			base.Configure(builder);
		}
		#endregion
	}
}
