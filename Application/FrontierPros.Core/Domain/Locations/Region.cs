using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Locations
{
	public class Region : BaseEntity
	{
		public string Name { get; set; }
		public int CountryId { get; set; }
		public virtual Country Country { get; set; }
		public virtual ICollection<City> Cities { get; set; }
	}
}
