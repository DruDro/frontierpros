using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontierPros.Core.Domain.Questions;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;


namespace FrontierPros.Data.Mapping.Questions
{
	public partial class OptionMap : NopEntityTypeConfiguration<Option>
	{
		public override void Configure(EntityTypeBuilder<Option> builder)
		{
			builder.ToTable(nameof(Option));
			builder.HasKey(option => option.Id);

			builder.HasOne(option => option.Question)
				.WithMany(question => question.Options)
				.HasForeignKey(option => option.QuestionId);

			builder.HasOne(option => option.NextQuestion)
				.WithMany()
				.HasForeignKey(option => option.NextQuestionId);

			builder.HasOne(option => option.Specialty)
				.WithMany(specialty => specialty.Options)
				.HasForeignKey(option => option.SpecialtyId);

			base.Configure(builder);
		}
	}
}
