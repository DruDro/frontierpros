using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Catalog
{
	public partial class ServiceInfoAndNameTokenMap : NopEntityTypeConfiguration<ServiceInfoAndNameToken>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceInfoAndNameToken> builder)
		{
			builder.ToTable(nameof(ServiceInfoAndNameToken));
			builder.HasKey(serviceInfoAndNameToken => serviceInfoAndNameToken.Id);

			builder.HasOne(serviceInfoAndNameToken => serviceInfoAndNameToken.ServiceInfo)
				.WithMany(category => category.NameTokens)
				.HasForeignKey(serviceInfoAndNameToken => serviceInfoAndNameToken.ServiceInfoId)
				.IsRequired();

			builder.HasOne(serviceInfoAndNameToken => serviceInfoAndNameToken.NameToken)
				.WithMany()
				.HasForeignKey(serviceInfoAndNameToken => serviceInfoAndNameToken.NameTokenId)
				.IsRequired();

			base.Configure(builder);
		}

		#endregion
	}
}
