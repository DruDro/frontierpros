using FrontierPros.Core.Domain.Questions;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Services
{
	public class ServiceItemSettings : BaseEntity
	{
		public decimal? Price { get; set; }
		public bool IsActive { get; set; }

		public int ServiceItemId { get; set; }
		public virtual ServiceItem ServiceItem { get; set; }

		public int OptionId { get; set; }
		public virtual Option Option { get; set; }
	}
}
