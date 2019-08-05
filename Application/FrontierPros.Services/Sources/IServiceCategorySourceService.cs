using System.Collections.Generic;
using Nop.Core;
using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Sources;

namespace FrontierPros.Services.Sources
{
	public partial interface IServiceCategorySourceService
	{
		ServiceCategorySource GetServiceCategorySourceById(int serviceCategorySourceId);
		
		IPagedList<ServiceCategorySource> GetAllServiceCategorySources(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

		IList<ServiceInfoSource> GetServices(int serviceCategoryId, bool showHidden = false);

		void InsertServiceCategorySource(ServiceCategorySource serviceCategorySource);
		void UpdateServiceCategorySource(ServiceCategorySource serviceCategorySource);
		void DeleteServiceCategorySource(ServiceCategorySource serviceCategorySource);
	}
}