using FrontierPros.Core.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrontierPros.Services.Providers
{
	public interface IProviderService
	{
		void DeleteProvider(Provider provider);

		IList<Provider> GetAllProviders(string name = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

		Provider GetProviderById(int providerId);
        Provider GetProviderByCustomerId(int customerId);

        void InsertProvider(Provider provider);

		Task UpdateProviderAsync(Provider provider, bool synchronize = false);
	}
}
