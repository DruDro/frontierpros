using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class AddonSourceMap : NopEntityTypeConfiguration<AddonSource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<AddonSource> builder)
		{
			builder.ToTable(nameof(AddonSource));
			builder.HasKey(addon => addon.Id);

			builder.HasOne(addon => addon.ServiceInfo)
				.WithMany()
				.HasForeignKey(addon => addon.ServiceInfoSourceId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
