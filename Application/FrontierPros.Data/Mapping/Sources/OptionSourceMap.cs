using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontierPros.Core.Domain.Sources;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;


namespace FrontierPros.Data.Mapping.Sources
{
	public partial class OptionSourceMap : NopEntityTypeConfiguration<OptionSource>
	{
		public override void Configure(EntityTypeBuilder<OptionSource> builder)
		{
			builder.ToTable(nameof(OptionSource));
			builder.HasKey(option => option.Id);

			builder.HasOne(option => option.Question)
				.WithMany(question => question.Options)
				.HasForeignKey(option => option.QuestionSourceId);

			builder.HasOne(option => option.NextQuestion)
				.WithMany()
				.HasForeignKey(option => option.NextQuestionSourceId);

			builder.HasOne(option => option.Specialty)
				.WithMany(specialty => specialty.Options)
				.HasForeignKey(option => option.SpecialtySourceId);

			base.Configure(builder);
		}
	}
}
