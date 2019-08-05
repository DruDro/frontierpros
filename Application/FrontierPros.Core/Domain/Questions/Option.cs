using FrontierPros.Core.Domain.Specialties;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Questions
{
	public class Option : BaseEntity
	{
		public string ProviderText { get; set; }
		public string Text { get; set; }
		public string Placeholder { get; set; }
		public int Order { get; set; }

		public int? SpecialtyId { get; set; }
		public virtual Specialty Specialty { get; set; }

		public int? QuestionId { get; set; }
		public virtual Question Question { get; set; }

		public int? NextQuestionId { get; set; }
		public virtual Question NextQuestion { get; set; }
	}
}
