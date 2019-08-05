using Nop.Core;
using System.Collections.Generic;

namespace FrontierPros.Core.Domain.Sources
{
	public class SpecialtySource : BaseEntity
	{
		private ICollection<OptionSource> _options;

		public string Heading { get; set; }

		public int ServiceInfoSourceId { get; set; }
		public virtual ServiceInfoSource ServiceInfo { get; set; }

		public int Order { get; set; }

		public virtual ICollection<OptionSource> Options
		{
			get => _options ?? (_options = new List<OptionSource>());
			protected set => _options = value;
		}
	}
}
