using FrontierPros.Core.Domain.ServiceProviders;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.ServiceProviders
{
	public interface IServiceProviderService
	{
		ServiceProvider GetServiceProviderById(int serviceProviderId);

		IList<ServiceProvider> GetServiceProviderByProviderId(int providerId);

		void DeleteServiceProvider(ServiceProvider serviceProvider);

		IPagedList<ServiceProvider> GetAllServiceProviders(int? providerId = null, string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

		IList<ServiceProvider> GetServiceProvidersByIds(int[] serviceProviderIds);

		void InsertServiceProvider(ServiceProvider serviceProvider);

		void UpdateServiceProvider(ServiceProvider serviceProvider);
	}
}
