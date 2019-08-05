using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Locations
{
	public class Country : BaseEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public virtual ICollection<Region> Regions { get; set; }
		public virtual ICollection<City> Cities { get; set; }
	}
}
