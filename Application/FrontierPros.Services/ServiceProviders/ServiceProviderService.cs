using FrontierPros.Core.Domain.Providers;
using FrontierPros.Core.Domain.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Vendors;
using Nop.Services.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontierPros.Services.ServiceProviders
{
	public class ServiceProviderService : IServiceProviderService
	{
		#region Fields

		private readonly IRepository<ServiceProvider> _serviceProviderRepository;
		private readonly IRepository<ProviderAndServiceProvider> _providerAndServiceProviderRepository;
		private readonly IRepository<Vendor> _vendorRepository;
		private readonly IVendorService _vendorService;
		private readonly IRepository<Provider> _providerRepository;

		#endregion

		#region Ctor

		public ServiceProviderService(IRepository<ServiceProvider> serviceProviderRepository,
			IRepository<ProviderAndServiceProvider> providerAndServiceProviderRepository,
			IRepository<Vendor> vendorRepository,
			IVendorService vendorService,
			IRepository<Provider> providerRepository)
		{
			this._serviceProviderRepository = serviceProviderRepository;
			this._providerAndServiceProviderRepository = providerAndServiceProviderRepository;

			this._vendorService = vendorService;
			this._vendorRepository = vendorRepository;

			this._providerRepository = providerRepository;
		}

		#endregion

		#region Methods

		public virtual ServiceProvider GetServiceProviderById(int serviceProviderId)
		{
			return _serviceProviderRepository.GetById(serviceProviderId);
		}

		public virtual void DeleteServiceProvider(ServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException(nameof(serviceProvider));
			serviceProvider.Deleted = true;
			_serviceProviderRepository.Update(serviceProvider);

			var vendor = _vendorRepository.GetById(serviceProvider.VendorId);
			_vendorService.DeleteVendor(vendor);
		}

		public virtual IPagedList<ServiceProvider> GetAllServiceProviders(int? providerId = null, string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
		{
			var query = _serviceProviderRepository.TableNoTracking;

			if (providerId.HasValue)
			{
				query = _providerAndServiceProviderRepository.TableNoTracking.Include(s => s.ServiceProvider)
					.Where(s => s.ProviderId == providerId)
					.Select(s => s.ServiceProvider);
			}

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(sp => sp.Name.Contains(name));

			if (!showHidden)
				query = query.Where(sp => sp.Active);

			query = query.Where(sp => !sp.Deleted);

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);

			var serviceProviders = new PagedList<ServiceProvider>(query, pageIndex, pageSize);
			return serviceProviders;
		}

		public virtual IList<ServiceProvider> GetServiceProvidersByIds(int[] serviceProviderIds)
		{
			var query = _serviceProviderRepository.Table;
			if (serviceProviderIds != null)
				query = query.Where(v => serviceProviderIds.Contains(v.Id));

			return query.ToList();
		}

		public virtual void InsertServiceProvider(ServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException(nameof(serviceProvider));

			var vendor = new Vendor()
			{
				Name = serviceProvider.Name,
				Email = serviceProvider.Email,
				Deleted = serviceProvider.Deleted,
				Active = serviceProvider.Active,
				AllowCustomersToSelectPageSize = true,      //default
				PageSizeOptions = "6, 3, 9"                 //default
			};

			_vendorService.InsertVendor(vendor);

			serviceProvider.VendorId = vendor.Id;
			_serviceProviderRepository.Insert(serviceProvider);
		}

		public virtual void UpdateServiceProvider(ServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException(nameof(serviceProvider));

			_serviceProviderRepository.Update(serviceProvider);

			var vendor = _vendorRepository.GetById(serviceProvider.VendorId);
			vendor.Email = serviceProvider.Email;
			vendor.Name = serviceProvider.Name;
			vendor.Active = serviceProvider.Active;
			vendor.Deleted = serviceProvider.Deleted;
			_vendorService.UpdateVendor(vendor);
		}

		public virtual IList<ServiceProvider> GetServiceProviderByProviderId(int providerId)
		{
			var query = _providerAndServiceProviderRepository.TableNoTracking
				.Include(s => s.ServiceProvider)
				.Where(s => s.ProviderId == providerId)
				.Select(s => s.ServiceProvider);

			return query.ToList();
		}
		#endregion
	}
}
