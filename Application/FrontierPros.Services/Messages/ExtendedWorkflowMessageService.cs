using FrontierPros.Core.Domain.Messages;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Messages;
using Nop.Services.Affiliates;
using Nop.Services.Customers;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontierPros.Services.Messages
{
	public class ExtendedWorkflowMessageService : WorkflowMessageService, IExtendedWorkflowMessageService
	{
		#region Fields

		private readonly CommonSettings _commonSettings;
		private readonly EmailAccountSettings _emailAccountSettings;
		private readonly IAffiliateService _affiliateService;
		private readonly ICustomerService _customerService;
		private readonly IEmailAccountService _emailAccountService;
		private readonly IEventPublisher _eventPublisher;
		private readonly ILanguageService _languageService;
		private readonly ILocalizationService _localizationService;
		private readonly IMessageTemplateService _messageTemplateService;
		private readonly IMessageTokenProvider _messageTokenProvider;
		private readonly IQueuedEmailService _queuedEmailService;
		private readonly IStoreContext _storeContext;
		private readonly IStoreService _storeService;
		private readonly ITokenizer _tokenizer;

		#endregion

		public ExtendedWorkflowMessageService(CommonSettings commonSettings,
			EmailAccountSettings emailAccountSettings,
			IAffiliateService affiliateService,
			ICustomerService customerService,
			IEmailAccountService emailAccountService,
			IEventPublisher eventPublisher,
			ILanguageService languageService,
			ILocalizationService localizationService,
			IMessageTemplateService messageTemplateService,
			IMessageTokenProvider messageTokenProvider,
			IQueuedEmailService queuedEmailService,
			IStoreContext storeContext,
			IStoreService storeService,
			ITokenizer tokenizer) : base(commonSettings, emailAccountSettings, affiliateService, customerService, emailAccountService, eventPublisher, languageService, localizationService, messageTemplateService, messageTokenProvider, queuedEmailService, storeContext, storeService, tokenizer)
		{
			this._commonSettings = commonSettings;
			this._emailAccountSettings = emailAccountSettings;
			this._affiliateService = affiliateService;
			this._customerService = customerService;
			this._emailAccountService = emailAccountService;
			this._eventPublisher = eventPublisher;
			this._languageService = languageService;
			this._localizationService = localizationService;
			this._messageTemplateService = messageTemplateService;
			this._messageTokenProvider = messageTokenProvider;
			this._queuedEmailService = queuedEmailService;
			this._storeContext = storeContext;
			this._storeService = storeService;
			this._tokenizer = tokenizer;
		}

		public virtual IList<int> SendCustomerCustomEmailVerificationMessage(Customer customer, string unverifiedEmail, string confirmationCode, int languageId)
		{
			if (customer == null)
				throw new ArgumentNullException(nameof(customer));

			var store = _storeContext.CurrentStore;
			languageId = EnsureLanguageIsActive(languageId, store.Id);

			var messageTemplates = GetActiveMessageTemplates(CustomMessageTemplateSystemNames.CustomerCustomEmailVerificationMessage, store.Id);
			if (!messageTemplates.Any())
				return new List<int>();

			//tokens
			var commonTokens = new List<Token>();
			_messageTokenProvider.AddCustomerTokens(commonTokens, customer);

			return messageTemplates.Select(messageTemplate =>
			{
				//email account
				var emailAccount = GetEmailAccountOfMessageTemplate(messageTemplate, languageId);

				var tokens = new List<Token>(commonTokens);
				_messageTokenProvider.AddStoreTokens(tokens, store, emailAccount);

				tokens.Add(new Token("Customer.ConfirmationCode", confirmationCode));

				//event notification
				_eventPublisher.MessageTokensAdded(messageTemplate, tokens);

				var toEmail = unverifiedEmail;
				var toName = _customerService.GetCustomerFullName(customer);

				return SendNotification(messageTemplate, emailAccount, languageId, tokens, toEmail, toName);
			}).ToList();
		}
	}
}
