using Nop.Core;

namespace FrontierPros.Core.Domain.Catalog
{
	public class AddonItem : BaseEntity
	{
		public string Name { get; set; }
		public int AddonId { get; set; }
		public virtual Addon Addon { get; set; }
	}
}
