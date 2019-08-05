using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Questions;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Sources
{
	public class QuestionSource : BaseEntity
	{
		private ICollection<OptionSource> _options;

		public string ProviderHeading { get; set; }
		public string ProviderSubHeading { get; set; }

		public string Heading { get; set; }
		public string SubHeading { get; set; }

		public string Placeholder { get; set; }

		public AnswerType Type { get; set; }
		public bool IsStartQuestion { get; set; }
		public bool IsRequired { get; set; }
		public bool IsProviderQuestion { get; set; }
		public bool IsPaidQuestion { get; set; }
		public int Order { get; set; }

		public int ServiceInfoSourceId { get; set; }
		public virtual ServiceInfoSource ServiceInfo { get; set; }

		public int? NextQuestionSourceId { get; set; }
		public virtual QuestionSource NextQuestion { get; set; }

		public virtual ICollection<OptionSource> Options
		{
			get => _options ?? (_options = new List<OptionSource>());
			protected set => _options = value;
		}
	}
}
