using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Customers
{
	public class ExtendedCustomerDefaults
	{
		#region System customer roles

		/// <summary>
		/// Gets a system name of 'members' customer role
		/// </summary>
		public static string MembersRoleName => "Members";

		/// <summary>
		/// Gets a system name of 'service providers' customer role
		/// </summary>
		public static string ServiceProvidersRoleName => "ServiceProviders";

		/// <summary>
		/// Gets a system name of 'providers' customer role
		/// </summary>
		public static string ProvidersRoleName => "Providers";
        #endregion

        #region System customers
        #endregion

        #region Customer attributes
        //public static string ProviderIdAttribute => "ProviderId";
        public static string NameAttribute => "Name";
        public static string CountryAttribute => "Country";
        public static string EmailAttribute => "Email";
        public static string AddressAttribute => "Address";

		public static string PhoneConfirmCodeAttribute => "ConfirmationCode";
		public static string PhoneConfirmCodeExpirationDateAttribute => "ConfirmCodeExpirationDate";

		public static string EmailConfirmCodeAttribute => "EmailConfirmationCode";
		public static string EmailConfirmCodeExpirationDateAttribute => "EmailConfirmCodeExpirationDate";

		public static string PhoneVerifiedAttribute => "PhoneVerified";

		public static string UnverifiedEmailAttribute => "UnverifiedEmail";
		#endregion
	}
}
