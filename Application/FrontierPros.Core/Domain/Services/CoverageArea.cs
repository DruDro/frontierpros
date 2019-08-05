using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Services
{
	public class CoverageArea : BaseEntity
	{
		public string Country { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
		public double? DistanceTravel { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public bool IsServiceLocation { get; set; }

		public int ServiceItemId { get; set; }
		public virtual ServiceItem ServiceItem { get; set; }
	}
}
