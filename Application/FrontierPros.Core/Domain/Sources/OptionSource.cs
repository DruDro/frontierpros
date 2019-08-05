using FrontierPros.Core.Domain.Specialties;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Sources
{
	public class OptionSource : BaseEntity
	{
		public string ProviderText { get; set; }
		public string Text { get; set; }

		public string Placeholder { get; set; }
		public int Order { get; set; }

		public int? SpecialtySourceId { get; set; }
		public virtual SpecialtySource Specialty { get; set; }

		public int? QuestionSourceId { get; set; }
		public virtual QuestionSource Question { get; set; }

		public int? NextQuestionSourceId { get; set; }
		public virtual QuestionSource NextQuestion { get; set; }
	}
}
