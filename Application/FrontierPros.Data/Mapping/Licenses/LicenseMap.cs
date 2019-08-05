using FrontierPros.Core.Domain.Licenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Licenses
{
	public partial class LicenseMap : NopEntityTypeConfiguration<License>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<License> builder)
		{
			builder.ToTable($"tbl{nameof(License)}");
			builder.HasKey(l => l.Id);

			builder.HasOne(l => l.Provider)
				.WithMany(provider => provider.Licenses)
				.HasForeignKey(l => l.ProviderId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
