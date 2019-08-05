using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class ServiceInfoSourceAndNameTokenSourceMap : NopEntityTypeConfiguration<ServiceInfoSourceAndNameTokenSource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceInfoSourceAndNameTokenSource> builder)
		{
			builder.ToTable(nameof(ServiceInfoSourceAndNameTokenSource));
			builder.HasKey(categoryNameToken => categoryNameToken.Id);

			builder.HasOne(CategoryNameToken => CategoryNameToken.ServiceInfo)
				.WithMany(category => category.NameTokens)
				.HasForeignKey(categoryNameToken => categoryNameToken.ServiceInfoSourceId)
				.IsRequired();

			builder.HasOne(categoryNameToken => categoryNameToken.NameToken)
				.WithMany()
				.HasForeignKey(categoryNameToken => categoryNameToken.NameTokenSourceId)
				.IsRequired();

			base.Configure(builder);
		}

		#endregion
	}
}
