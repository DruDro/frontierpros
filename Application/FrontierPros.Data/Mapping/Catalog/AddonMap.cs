using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Catalog
{
	public partial class AddonMap : NopEntityTypeConfiguration<Addon>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<Addon> builder)
		{
			builder.ToTable(nameof(Addon));
			builder.HasKey(addon => addon.Id);

			builder.HasOne(addon => addon.ServiceInfo)
				.WithMany()
				.HasForeignKey(addon => addon.ServiceInfoId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
