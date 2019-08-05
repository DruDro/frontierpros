using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Questions;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Specialties
{
	public class Specialty : BaseEntity
	{
		private ICollection<Option> _options;

		public string Heading { get; set; }

		public int ServiceInfoId { get; set; }
		public virtual ServiceInfo ServiceInfo { get; set; }

		public int Order { get; set; }

		public virtual ICollection<Option> Options
		{
			get => _options ?? (_options = new List<Option>());
			protected set => _options = value;
		}
	}
}
