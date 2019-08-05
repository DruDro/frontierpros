using FrontierPros.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Services
{
	public interface IServiceItemService
	{
		ServiceItem GetServiceItemById(int serviceId);
		IList<ServiceItem> GetServiceItemsByProviderId(int providerId);
		IList<ServiceItem> GetAllServiceItems(string searchTerm,
											int? serviceCategoryId = null,
											int? serviceInfoId = null,
											WorkLocationType? workLocationType = null,
											double? latitude = null,
											double? longitude = null,
											double? distanceTravel = null,
											int pageIndex = 0,
											int pageSize = int.MaxValue);

		void InsertServiceItem(ServiceItem Service);
		void UpdateServiceItem(ServiceItem Service);
		void DeleteServiceItem(ServiceItem service);
	}
}
