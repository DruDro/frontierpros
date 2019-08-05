using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class ServiceCategorySourceMap : NopEntityTypeConfiguration<ServiceCategorySource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceCategorySource> builder)
		{
			builder.ToTable(nameof(ServiceCategorySource));
			builder.HasKey(categoryGroup => categoryGroup.Id);

			base.Configure(builder);
		}
		#endregion
	}
}
