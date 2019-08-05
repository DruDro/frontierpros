using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Profile
{
	public class ProviderIndividualInfoModel
	{
		#region Properties
		public int Id { get; set; }

		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Website { get; set; }
		public int? FoundedYear { get; set; }

		public string WhyShouldCustomerHireYou { get; set; }
		public string YourIntroduction { get; set; }

		public string GalleryDescription { get; set; }
		#endregion
	}
}
