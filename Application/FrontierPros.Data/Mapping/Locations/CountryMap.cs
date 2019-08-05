using FrontierPros.Core.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Locations
{
	public partial class CountryMap : NopEntityTypeConfiguration<Country>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<Country> builder)
		{
			builder.ToTable($"tbl{nameof(Country)}");
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(c => c.Code)
					.IsRequired()
					.HasMaxLength(2);

			base.Configure(builder);
		}
		#endregion
	}
}
