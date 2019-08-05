using FluentValidation.Attributes;
using FrontierPros.Core.Domain.Questions;
using Nop.Core.Domain.Catalog;
using Nop.Web.Validators.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Web.Models.Catalog
{
	public class OptionModel
	{
		public int Id { get; set; }
		public string ProviderText { get; set; }
		public string Text { get; set; }
		public string Placeholder { get; set; }
		public int Order { get; set; }
		//public int? SpecialtyId { get; set; }
		public int? QuestionId { get; set; }
		public int? NextQuestionId { get; set; }
	}

	public class QuestionModel
	{
		public int Id { get; set; }
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

		public int? NextQuestionId { get; set; }
		public List<OptionModel> Options { get; set; }
	}

	public class QuestionnaireModel
	{
		public List<QuestionModel> Questions { get; set; }
	}
}