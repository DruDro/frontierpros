using System.Collections.Generic;
using Nop.Core;
using FrontierPros.Core.Domain.Catalog;

namespace FrontierPros.Services.Catalog
{
	public partial interface IServiceInfoService
	{
		ServiceInfo GetServiceInfoById(int serviceInfoId, bool includeCategories = false);
		bool IsExistServiceInfo(int serviceInfoId);
		ServiceInfo GetServiceInfoByName(string name);
		void DeleteServiceInfo(ServiceInfo serviceInfo);
		IPagedList<ServiceInfo> GetAllServiceInfoEntities(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool includeCategories = false, bool showHidden = false);
		void InsertServiceInfo(ServiceInfo serviceInfo);
		void UpdateServiceInfo(ServiceInfo serviceInfo);
    }
}