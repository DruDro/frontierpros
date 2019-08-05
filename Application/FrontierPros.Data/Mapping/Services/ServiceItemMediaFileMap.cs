using FrontierPros.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Services
{
	public class ServiceItemMediaFileMap : NopEntityTypeConfiguration<ServiceItemMediaFile>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceItemMediaFile> builder)
		{
			builder.ToTable($"tbl{nameof(ServiceItemMediaFile)}");
			builder.HasKey(mediaFile => mediaFile.Id);

			builder.HasOne(mediaFile => mediaFile.ServiceItem)
				.WithMany(serviceItem => serviceItem.MediaFiles)
				.HasForeignKey(mediaFile => mediaFile.ServiceItemId)
				.IsRequired();

			base.Configure(builder);
		}
		#endregion
	}
}
