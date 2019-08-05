using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class ServiceInfoSourceMap : NopEntityTypeConfiguration<ServiceInfoSource>
	{
		#region Methods
		public override void Configure(EntityTypeBuilder<ServiceInfoSource> builder)
		{
			builder.ToTable(nameof(ServiceInfoSource));
			builder.HasKey(categoryInfoSource => categoryInfoSource.Id);

			base.Configure(builder);
		}
		#endregion
	}
}
