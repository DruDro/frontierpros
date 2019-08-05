using FrontierPros.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Services
{
	public class DiscountRateMap : NopEntityTypeConfiguration<DiscountRate>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<DiscountRate> builder)
		{
			builder.ToTable($"tbl{nameof(DiscountRate)}");
			builder.HasKey(discountRate => discountRate.Id);

			builder.HasOne(discountRate => discountRate.ServiceItem)
				.WithMany(serviceItem => serviceItem.DiscountRates)
				.HasForeignKey(discountRate => discountRate.ServiceItemId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
