using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class SpecialtyMap : NopEntityTypeConfiguration<SpecialtySource>
	{
		public override void Configure(EntityTypeBuilder<SpecialtySource> builder)
		{
			builder.ToTable(nameof(SpecialtySource));
			builder.HasKey(specialty => specialty.Id);

			builder.HasOne(specialty => specialty.ServiceInfo)
				.WithMany()
				.HasForeignKey(specialty => specialty.ServiceInfoSourceId)
				.IsRequired();

			base.Configure(builder);
		}
	}
}
