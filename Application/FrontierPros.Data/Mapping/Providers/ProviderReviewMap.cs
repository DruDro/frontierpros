using FrontierPros.Core.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Providers
{
	class ProviderReviewMap : NopEntityTypeConfiguration<ProviderReview>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ProviderReview> builder)
		{
			builder.ToTable($"tbl{nameof(ProviderReview)}");
			builder.HasKey(review => review.Id);

			builder.HasOne(provider => provider.Customer)
			.WithMany()
			.HasForeignKey(provider => provider.CustomerId)
			.IsRequired();

			builder.HasOne(review => review.Provider)
				.WithMany(provider => provider.Reviews)
				.HasForeignKey(provider => provider.ProviderId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
