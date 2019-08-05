using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Models.Profile
{
	public class ProviderBusinessInfoModel
	{
		#region Properties
		public int Id { get; set; }
		[Required]
		public string CompanyName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Website { get; set; }
		public int? FoundedYear { get; set; }
		public int? NumberOfEmployees { get; set; }
		public string WhyShouldCustomerHireYou { get; set; }
		public string YourIntroduction { get; set; }
		#endregion
	}
}
