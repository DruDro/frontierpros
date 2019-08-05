using FrontierPros.Core.Domain.Providers;
using FrontierPros.Services.ADB2CGraph;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Events;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontierPros.Services.Providers
{
	public class ProviderService : IProviderService
	{
		#region Fields
		private readonly IRepository<Provider> _providerRepository;
		private readonly IRepository<Store> _storeRepository;
		private readonly IRepository<StoreMapping> _storeMappingRepository;
		private readonly IRepository<ProductCategory> _productCategoryRepository;

		private readonly ICustomerService _customerService;
		private readonly IB2CGraphService _b2CGraphService;
		private readonly IStoreService _storeService;

		#endregion

		#region Ctor

		public ProviderService(IRepository<Provider> providerRepository,
			IRepository<Store> storeRepository,
			IRepository<StoreMapping> storeMappingRepository,
			IRepository<ProductCategory> productCategoryRepository,
			IStoreService storeService,
			ICategoryService categoryService,
			IB2CGraphService b2CGraphService,
			ICustomerService customerService,
			IStaticCacheManager cacheManager)
		{
			this._providerRepository = providerRepository;
			this._storeRepository = storeRepository;
			this._storeMappingRepository = storeMappingRepository;
			this._productCategoryRepository = productCategoryRepository;
			this._b2CGraphService = b2CGraphService;
			this._storeService = storeService;
			this._customerService = customerService;
		}

		#endregion

		#region Methods
		public virtual IList<Provider> GetAllProviders(string name = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
		{
			var query = _providerRepository.Table;

			if (!string.IsNullOrWhiteSpace(name))
			{
				query = query.Where(f => f.CompanyName.Contains(name));
			}

			if (!showHidden)
				query = query.Where(f => f.Active);

			var serviceProviders = new PagedList<Provider>(query, pageIndex, pageSize);
			return serviceProviders;
		}

		public virtual Provider GetProviderById(int providerId)
		{
			return _providerRepository.GetById(providerId);
		}

        public virtual Provider GetProviderByCustomerId(int customerId)
        {
            return _providerRepository.Table.FirstOrDefault(p => p.CustomerId == customerId);
        }

        public virtual void InsertProvider(Provider provider)
		{
			if (provider == null)
				throw new ArgumentNullException(nameof(provider));

			var store = new Store()
			{
				Name = provider.CompanyName ?? "No Name",
				CompanyName = provider.CompanyName,
				CompanyPhoneNumber = provider.PhoneNumber,
				Url = provider.Website,
				DisplayOrder = 7//default
			};

			store.CompanyAddress = provider.Address;

			_storeService.InsertStore(store);

			provider.StoreId = store.Id;
			_providerRepository.Insert(provider);
		}

		public virtual async Task UpdateProviderAsync(Provider provider, bool synchronize = false)
		{
			if (provider == null)
				throw new ArgumentNullException(nameof(provider));

			_providerRepository.Update(provider);

			var store = _storeRepository.GetById(provider.StoreId);

			store.Name = provider.CompanyName ?? string.Empty;
			store.CompanyName = provider.CompanyName;
			store.CompanyPhoneNumber = provider.PhoneNumber;
			store.CompanyAddress = provider.Address;
			store.Url = provider.Website;

			_storeService.UpdateStore(store);

			if (synchronize)
			{
				//Graph API synchronization
				var patch = new
				{
					givenName = provider.Name,
					surname = provider.Surname,
					displayName = $"{provider.Name ?? string.Empty} {provider.Surname ?? string.Empty}",
					country = provider.Country,
					state = provider.State,
					city = provider.City,
					streetAddress = provider.PersonalAddress
				};

				var customer = _customerService.GetCustomerById(provider.CustomerId);
				if (customer != null)
				{
					var externalAuthenticationRecord = customer.ExternalAuthenticationRecords.FirstOrDefault(r => r.ProviderSystemName == "ExternalAuth.ActiveDirectoryB2C");
					if (externalAuthenticationRecord != null)
					{
						await _b2CGraphService.UpdateUserAsync(externalAuthenticationRecord.ExternalIdentifier, patch);
					}
				}
			}
		}

		public virtual void DeleteProvider(Provider provider)
		{
			if (provider == null)
				throw new ArgumentNullException(nameof(provider));

			var store = _storeRepository.GetById(provider.StoreId);
			_storeService.DeleteStore(store);
		}
		#endregion
	}
}
