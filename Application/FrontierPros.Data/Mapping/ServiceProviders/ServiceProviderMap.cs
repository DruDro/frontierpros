using FrontierPros.Core.Domain.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.ServiceProviders
{
	public class ServiceProviderMap : NopEntityTypeConfiguration<ServiceProvider>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceProvider> builder)
		{
			builder.ToTable(nameof(ServiceProvider));
			builder.HasKey(serviceProvider => serviceProvider.Id);

			builder.HasOne(serviceProvider => serviceProvider.Vendor)
				.WithMany()
				.HasForeignKey(serviceProvider => serviceProvider.VendorId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
