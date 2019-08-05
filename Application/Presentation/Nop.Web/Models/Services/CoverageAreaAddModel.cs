using FrontierPros.Core.Domain.Services;
using Nop.Core.Domain.Catalog;
using System;

namespace Nop.Web.Models.Services
{
	public class CoverageAreaAddModel
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
	}
}