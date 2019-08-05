using FrontierPros.Core.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Locations
{
	public partial class RegionMap : NopEntityTypeConfiguration<Region>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<Region> builder)
		{
			builder.ToTable($"tbl{nameof(Region)}");
			builder.HasKey(r => r.Id); 

			builder.Property(r => r.Name)
				.IsRequired()
				.HasMaxLength(255);

			builder.HasOne(r => r.Country)
				.WithMany(c => c.Regions)
				.HasForeignKey(r => r.CountryId);

			base.Configure(builder);
		}
		#endregion
	}
}
