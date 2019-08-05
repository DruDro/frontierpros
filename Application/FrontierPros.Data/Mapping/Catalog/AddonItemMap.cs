using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Catalog
{
	public partial class AddonItemMap : NopEntityTypeConfiguration<AddonItem>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<AddonItem> builder)
		{
			builder.ToTable(nameof(AddonItem));
			builder.HasKey(addonItem => addonItem.Id);

			builder.HasOne(addonItem => addonItem.Addon)
				.WithMany(addon=>addon.AddonItems)
				.HasForeignKey(addonItem => addonItem.AddonId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
