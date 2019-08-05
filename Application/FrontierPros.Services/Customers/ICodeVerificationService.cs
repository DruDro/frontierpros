using Nop.Core.Domain.Customers;

namespace FrontierPros.Services.Customers
{
    public partial interface ICodeVerificationService
    {
		bool SendCodeOnPhoneNumber(int customerId, string phoneNumber);
		bool SendCodeOnEmail(int customerId, string email, int languageId);

		bool IsPhoneCodeValid(int customerId, string code);
		bool IsEmailCodeValid(int customerId, string code);

		string GenerateNewCode();
	}
}