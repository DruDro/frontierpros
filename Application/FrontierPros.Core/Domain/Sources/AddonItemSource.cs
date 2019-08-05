using Nop.Core;

namespace FrontierPros.Core.Domain.Sources
{
	public class AddonItemSource : BaseEntity
	{
		public string Name { get; set; }
		public int AddonSourceId { get; set; }
		public virtual AddonSource Addon { get; set; }
	}
}
