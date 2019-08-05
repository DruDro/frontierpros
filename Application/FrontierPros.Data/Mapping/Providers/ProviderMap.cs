using FrontierPros.Core.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Providers
{
	public class ProviderMap : NopEntityTypeConfiguration<Provider>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<Provider> builder)
		{
			builder.ToTable(nameof(Provider));
			builder.HasKey(provider => provider.Id);

			builder.HasOne(provider => provider.Store)
				.WithMany()
				.HasForeignKey(provider => provider.StoreId)
				.IsRequired();

            builder.HasOne(provider => provider.Customer)
            .WithMany()
            .HasForeignKey(provider => provider.CustomerId)
            .IsRequired();

            base.Configure(builder);
		}
		#endregion
	}
}
