using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Customers
{
	public class CustomerMediaFileMap : NopEntityTypeConfiguration<CustomerMediaFile>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<CustomerMediaFile> builder)
		{
			builder.ToTable($"tbl{nameof(CustomerMediaFile)}");
			builder.HasKey(mediaFile => mediaFile.Id);

			builder.HasOne(mediaFile => mediaFile.Customer)
				.WithMany()
				.HasForeignKey(mediaFile => mediaFile.CustomerId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
