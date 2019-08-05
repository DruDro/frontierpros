using FrontierPros.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Services
{
	public class CoverageAreaMap : NopEntityTypeConfiguration<CoverageArea>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<CoverageArea> builder)
		{
			builder.ToTable(nameof(CoverageArea));
			builder.HasKey(coverageArea => coverageArea.Id);

			builder.HasOne(coverageArea => coverageArea.ServiceItem)
				.WithMany(service => service.CoverageAreas)
				.HasForeignKey(coverageArea => coverageArea.ServiceItemId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
