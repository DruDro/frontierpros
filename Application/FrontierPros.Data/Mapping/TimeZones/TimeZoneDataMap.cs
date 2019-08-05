using FrontierPros.Core.Domain.TimeZones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.TimeZones
{
	public partial class TimeZoneDataMap : NopEntityTypeConfiguration<TimeZoneData>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<TimeZoneData> builder)
		{
			builder.ToTable($"tbl{nameof(TimeZoneData)}");
			builder.HasKey(c => c.Id);

			builder.Property(c => c.StandardName)
					.IsRequired()
					.HasMaxLength(255);

			builder.Property(c => c.TimeZoneId)
					.IsRequired()
					.HasMaxLength(255);

			base.Configure(builder);
		}
		#endregion
	}
}
