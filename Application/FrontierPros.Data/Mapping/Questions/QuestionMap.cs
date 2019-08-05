using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontierPros.Core.Domain.Questions;
using Nop.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data.Mapping.Questions
{
	public partial class QuestionMap : NopEntityTypeConfiguration<Question>
	{
		public override void Configure(EntityTypeBuilder<Question> builder)
		{
			builder.ToTable(nameof(Question));
			builder.HasKey(question => question.Id);

			builder.HasOne(question => question.ServiceInfo)
				.WithMany()
				.HasForeignKey(question => question.ServiceInfoId)
				.IsRequired();

			builder.HasOne(question => question.NextQuestion)
				.WithMany()
				.HasForeignKey(facility => facility.NextQuestionId);

			base.Configure(builder);
		}
	}
}
