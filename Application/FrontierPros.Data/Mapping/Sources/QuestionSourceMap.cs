using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontierPros.Core.Domain.Sources;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Sources
{
	public partial class QuestionSourceMap : NopEntityTypeConfiguration<QuestionSource>
	{
		public override void Configure(EntityTypeBuilder<QuestionSource> builder)
		{
			builder.ToTable(nameof(QuestionSource));
			builder.HasKey(question => question.Id);

			builder.HasOne(question => question.ServiceInfo)
				.WithMany()
				.HasForeignKey(question => question.ServiceInfoSourceId)
				.IsRequired();

			builder.HasOne(question => question.NextQuestion)
				.WithMany()
				.HasForeignKey(facility => facility.NextQuestionSourceId);

			base.Configure(builder);
		}
	}
}
