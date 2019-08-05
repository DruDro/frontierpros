using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class AddonItemSourceMap : NopEntityTypeConfiguration<AddonItemSource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<AddonItemSource> builder)
		{
			builder.ToTable(nameof(AddonItemSource));
			builder.HasKey(addonItem => addonItem.Id);

			builder.HasOne(addonItem => addonItem.Addon)
				.WithMany(addon=>addon.AddonItems)
				.HasForeignKey(addonItem => addonItem.AddonSourceId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
