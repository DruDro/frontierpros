using System.Collections.Generic;
using Nop.Core;
using FrontierPros.Core.Domain.Catalog;

namespace FrontierPros.Services.ServiceCategories
{
	public partial interface IServiceCategoryService
	{
		ServiceCategory GetServiceCategoryById(int serviceCategoryId);

		ServiceCategory GetServiceCategoryByName(string name);
		
		IPagedList<ServiceCategory> GetAllServiceCategories(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

		IList<ServiceInfo> GetServices(int serviceCategoryId, bool showHidden = false);

		void InsertServiceCategory(ServiceCategory serviceCategory);
		void UpdateServiceCategory(ServiceCategory serviceCategory);
		void DeleteServiceCategory(ServiceCategory serviceCategory);
	}
}