using FrontierPros.Core.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Locations
{
	public partial class CityMap : NopEntityTypeConfiguration<City>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<City> builder)
		{
			builder.ToTable($"tbl{nameof(City)}");
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name)
					.IsRequired()
					.HasMaxLength(255);

			builder.Property(c => c.Latitude)
					.HasColumnType("decimal(10,8)");

			builder.Property(c => c.Longitude)
				.HasColumnType("decimal(11,8)");

			builder.HasOne(c => c.Region)
				.WithMany(r => r.Cities)
				.HasForeignKey(c => c.RegionId);

			builder.HasOne(c => c.Country)
				.WithMany(r => r.Cities)
				.HasForeignKey(c => c.CountryId);

			base.Configure(builder);
		}
		#endregion
	}
}
