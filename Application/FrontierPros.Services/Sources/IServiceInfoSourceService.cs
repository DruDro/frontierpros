using Nop.Core;
using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Sources;

namespace FrontierPros.Services.Sources
{
	public partial interface IServiceInfoSourceService
	{
		ServiceInfoSource GetServiceInfoSourceById(int serviceInfoSourceId);
		void DeleteServiceInfoSource(ServiceInfoSource serviceInfoSource);
		IPagedList<ServiceInfoSource> GetAllServiceInfoSources(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);
		void InsertServiceInfoSource(ServiceInfoSource serviceInfoSource);
		void UpdateServiceInfoSource(ServiceInfoSource serviceInfoSource);
    }
}