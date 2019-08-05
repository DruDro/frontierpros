using FrontierPros.Core.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Providers
{
	public class ProviderAndServiceProviderMap : NopEntityTypeConfiguration<ProviderAndServiceProvider>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ProviderAndServiceProvider> builder)
		{
			builder.ToTable(nameof(ProviderAndServiceProvider));
			builder.HasKey(providerAndServiceProvider => providerAndServiceProvider.Id);

			builder.HasOne(providerAndServiceProvider => providerAndServiceProvider.Provider)
				.WithMany(provider=>provider.ServiceProviders)
				.HasForeignKey(providerAndServiceProvider => providerAndServiceProvider.ProviderId)
				.IsRequired();

			builder.HasOne(providerAndServiceProvider => providerAndServiceProvider.ServiceProvider)
				.WithMany()
				.HasForeignKey(providerAndServiceProvider => providerAndServiceProvider.ServiceProviderId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
