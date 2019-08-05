using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Catalog
{
	public partial class ServiceInfoMap : NopEntityTypeConfiguration<ServiceInfo>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceInfo> builder)
		{
			builder.ToTable(nameof(ServiceInfo));

			builder.HasKey(serviceInfo => serviceInfo.Id);

			builder.HasOne(serviceInfo => serviceInfo.Category)
				.WithMany()
				.HasForeignKey(serviceInfo => serviceInfo.CategoryId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
