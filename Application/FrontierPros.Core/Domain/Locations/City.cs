using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Locations
{
	public partial class City : BaseEntity
	{
		public string Name { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }

		public int RegionId { get; set; }
		public virtual Region Region { get; set; }

		public int CountryId { get; set; }
		public virtual Country Country { get; set; }
	}
}
