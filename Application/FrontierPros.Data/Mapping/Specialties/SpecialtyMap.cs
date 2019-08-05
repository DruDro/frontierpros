using FrontierPros.Core.Domain.Specialties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Specialties
{
	public partial class SpecialtyMap : NopEntityTypeConfiguration<Specialty>
	{
		public override void Configure(EntityTypeBuilder<Specialty> builder)
		{
			builder.ToTable(nameof(Specialty));
			builder.HasKey(specialty => specialty.Id);

			builder.HasOne(specialty => specialty.ServiceInfo)
				.WithMany()
				.HasForeignKey(specialty => specialty.ServiceInfoId)
				.IsRequired();

			base.Configure(builder);
		}
	}
}
