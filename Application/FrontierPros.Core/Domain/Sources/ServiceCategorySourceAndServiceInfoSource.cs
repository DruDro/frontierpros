using Nop.Core;

namespace FrontierPros.Core.Domain.Sources
{
	public class ServiceCategorySourceAndServiceInfoSource : BaseEntity
	{
		public int ServiceInfoSourceId { get; set; }
		public virtual ServiceInfoSource ServiceInfo { get; set; }

		public int ServiceCategorySourceId { get; set; }
		public virtual ServiceCategorySource ServiceCategory { get; set; }
	}
}
