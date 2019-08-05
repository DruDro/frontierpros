using System;
using System.Linq;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Services.Messages;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Services.Common;
using Nop.Services.Customers;

namespace FrontierPros.Services.Customers
{
    public partial class CodeVerificationService : ICodeVerificationService
	{
		#region Fields
		private static Random _random = new Random();
		private static string CONFIRMATION_TEXT_FORMAT = "Your FrontierPros confirmation code is {0}";
		public static int MIN_VALUE = 10000;
		public static int MAX_VALUE = 99999;

		private readonly IDbContext _dbContext;
        private readonly ISmsProviderService _smsProviderService;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
		private readonly IExtendedWorkflowMessageService _extendedWorkflowMessageService;
		#endregion

		#region Ctor

		public CodeVerificationService(IDbContext dbContext, 
            ISmsProviderService smsProviderService,
            ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
			IExtendedWorkflowMessageService extendedWorkflowMessageService)
        {
			this._dbContext = dbContext;
            this._smsProviderService = smsProviderService;
            this._customerService = customerService;
            this._genericAttributeService = genericAttributeService;
			this._extendedWorkflowMessageService = extendedWorkflowMessageService;
		}

		#endregion

		public bool SendCodeOnPhoneNumber(int customerId, string phoneNumber)
		{
            var result = false;

            var customer = _customerService.GetCustomerById(customerId);
            if(customer != null)
            {
                var code = GenerateNewCode();

                var text = string.Format(CONFIRMATION_TEXT_FORMAT, code);

                _genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.PhoneConfirmCodeAttribute, code);
                _genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.PhoneConfirmCodeExpirationDateAttribute, DateTime.UtcNow.AddDays(1));

                result = _smsProviderService.SendSms(phoneNumber, text);
            }

            return result;
		}

		public bool SendCodeOnEmail(int customerId, string email, int languageId)
		{
			var result = false;
			try
			{
				var customer = _customerService.GetCustomerById(customerId);
				if (customer != null)
				{
					var code = GenerateNewCode();

					_genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.EmailConfirmCodeAttribute, code);
					_genericAttributeService.SaveAttribute(customer, ExtendedCustomerDefaults.EmailConfirmCodeExpirationDateAttribute, DateTime.UtcNow.AddDays(1));

					_extendedWorkflowMessageService.SendCustomerCustomEmailVerificationMessage(customer, email, code, languageId);
					result = true;
				}
			}
			catch
			{

			}
			
			return result;
		}

		public string GenerateNewCode()
		{
            var code = _random.Next(MIN_VALUE, MAX_VALUE).ToString();
            return code;
		}

        public bool IsPhoneCodeValid(int customerId, string code)
        {
            var isValid = false;

            var customer = _customerService.GetCustomerById(customerId);
            if(customer != null)
            {
                var confirmationCode = _genericAttributeService.GetAttribute<string>(customer, ExtendedCustomerDefaults.PhoneConfirmCodeAttribute);
                var expirationDate = _genericAttributeService.GetAttribute<DateTime>(customer, ExtendedCustomerDefaults.PhoneConfirmCodeExpirationDateAttribute);

                return confirmationCode != null && expirationDate != null && expirationDate > DateTime.UtcNow && confirmationCode == code;
            }

            return isValid;
        }

		public bool IsEmailCodeValid(int customerId, string code)
		{
			var isValid = false;

			var customer = _customerService.GetCustomerById(customerId);
			if (customer != null)
			{
				var confirmationCode = _genericAttributeService.GetAttribute<string>(customer, ExtendedCustomerDefaults.EmailConfirmCodeAttribute);
				var expirationDate = _genericAttributeService.GetAttribute<DateTime>(customer, ExtendedCustomerDefaults.EmailConfirmCodeExpirationDateAttribute);

				return confirmationCode != null && expirationDate != null && expirationDate > DateTime.UtcNow && confirmationCode == code;
			}

			return isValid;
		}
	}
}