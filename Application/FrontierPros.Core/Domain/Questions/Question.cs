using FrontierPros.Core.Domain.Catalog;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Questions
{
	public enum AnswerType
	{
		MultiSelect,//checkboxes
		Select,//radio
		Email,//email
		ZipCode,//zipCode
		FullName,//fullname
		TextArea,//textarea
		Custom,//composite
		Text,
        Number,
        DropDown,//select
		Date,
		Location//location wizard
	};

	public class Question : BaseEntity
	{
		private ICollection<Option> _options;
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

		public int ServiceInfoId { get; set; }
		public virtual ServiceInfo ServiceInfo { get; set; }

		public int? NextQuestionId { get; set; }
		public virtual Question NextQuestion { get; set; }

		public virtual ICollection<Option> Options
		{
			get => _options ?? (_options = new List<Option>());
			protected set => _options = value;
		}
	}
}
