using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Sources
{
	public class NameTokenSourceMap : NopEntityTypeConfiguration<NameTokenSource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<NameTokenSource> builder)
		{
			builder.ToTable(nameof(NameTokenSource));
			builder.HasKey(nameToken => nameToken.Id);

			base.Configure(builder);
		}
		#endregion
	}
}
