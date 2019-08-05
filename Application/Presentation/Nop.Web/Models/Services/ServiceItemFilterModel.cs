using FrontierPros.Core.Domain.Services;

namespace Nop.Web.Models.Services
{
	public class ServiceItemFilterModel : PageModel
	{
		public string SearchTerm { get; set; }
		public int? ServiceCategoryId { get; set; }
		public int? ServiceInfoId { get; set; }
		public WorkLocationType? WorkLocationType { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public double? DistanceTravel { get; set; }
	}
}
