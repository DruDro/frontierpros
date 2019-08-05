using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Sources;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontierPros.Services.Sources
{
	public partial class ServiceInfoSourceService : IServiceInfoSourceService
	{
        #region Fields

        private readonly IRepository<ServiceInfoSource> _serviceInfoSourceRepository;
		#endregion

		#region Ctor

		public ServiceInfoSourceService(IRepository<ServiceInfoSource> serviceInfoSourceRepository)
        {
            this._serviceInfoSourceRepository = serviceInfoSourceRepository;
		}

		#endregion

		#region Methods

		public virtual ServiceInfoSource GetServiceInfoSourceById(int serviceInfoSourceId)
		{
			return _serviceInfoSourceRepository.GetById(serviceInfoSourceId);
		}

		public virtual void DeleteServiceInfoSource(ServiceInfoSource serviceInfoSource)
		{
			if (serviceInfoSource == null)
				throw new ArgumentNullException(nameof(serviceInfoSource));

			serviceInfoSource.Deleted = true;
			_serviceInfoSourceRepository.Update(serviceInfoSource);
		}

		public virtual IPagedList<ServiceInfoSource> GetAllServiceInfoSources(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
		{
			var query = _serviceInfoSourceRepository.TableNoTracking;

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(sp => sp.Name.Contains(name));

			query = query.Where(sp => !sp.Deleted);

			if (!showHidden)
			{
				query = query.Where(c => c.Published);
			}

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);

			var serviceInfoEntities = new PagedList<ServiceInfoSource>(query, pageIndex, pageSize);
			return serviceInfoEntities;
        }

		public virtual void InsertServiceInfoSource(ServiceInfoSource serviceInfoSource)
        {
			if (serviceInfoSource == null)
				throw new ArgumentNullException(nameof(serviceInfoSource));

			_serviceInfoSourceRepository.Insert(serviceInfoSource);
        }

		public virtual void UpdateServiceInfoSource(ServiceInfoSource serviceInfoSource)
		{
			if (serviceInfoSource == null)
				throw new ArgumentNullException(nameof(serviceInfoSource));

			_serviceInfoSourceRepository.Update(serviceInfoSource);
		}

		#endregion
	}
}