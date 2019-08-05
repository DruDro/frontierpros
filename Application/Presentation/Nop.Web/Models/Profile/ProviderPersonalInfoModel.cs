using System;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Models.Profile
{
	public class ProviderPersonalInfoModel
    {
        #region Properties
        public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		public string Gender { get; set; }

		public int BirthdayDay { get; set; }
		public int BirthdayYear { get; set; }
		public int BirthdayMonth { get; set; }

		public string Country { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PersonalAdress { get; set; }
		public string PersonalPhoneNumber { get; set; }
		public string Email { get; set; }
		public bool IsIndividualCompany { get; set; }
        #endregion
    }
}
