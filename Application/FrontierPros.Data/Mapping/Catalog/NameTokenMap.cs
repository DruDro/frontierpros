using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Catalog
{
	public class NameTokenMap : NopEntityTypeConfiguration<NameToken>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<NameToken> builder)
		{
			builder.ToTable(nameof(NameToken));
			builder.HasKey(nameToken => nameToken.Id);

			base.Configure(builder);
		}
		#endregion
	}
}
