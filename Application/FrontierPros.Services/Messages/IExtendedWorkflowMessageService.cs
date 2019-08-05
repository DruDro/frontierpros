using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Messages
{
	public interface IExtendedWorkflowMessageService
	{
		IList<int> SendCustomerCustomEmailVerificationMessage(Customer customer, string unverifiedEmail, string confirmationCode, int languageId);
	}
}
