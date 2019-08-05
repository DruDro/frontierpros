using FrontierPros.Core.Domain.Sources;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontierPros.Services.Sources
{
	public partial class ServiceCategorySourceService : IServiceCategorySourceService
	{
        #region Fields

        private readonly IRepository<ServiceCategorySource> _serviceCategorySourceRepository;
		private readonly IRepository<ServiceCategorySourceAndServiceInfoSource> _serviceCategorySourceAndServiceInfoSourceRepository;
		#endregion

		#region Ctor

		public ServiceCategorySourceService(IRepository<ServiceCategorySource> serviceCategorySourceRepository, 
			IRepository<ServiceCategorySourceAndServiceInfoSource> serviceCategorySourceAndServiceInfoSourceRepository)
        {
            this._serviceCategorySourceRepository = serviceCategorySourceRepository;
			this._serviceCategorySourceAndServiceInfoSourceRepository = serviceCategorySourceAndServiceInfoSourceRepository;
		}

		#endregion

		#region Methods
		public virtual ServiceCategorySource GetServiceCategorySourceById(int serviceCategorySourceId)
		{
			return _serviceCategorySourceRepository.GetById(serviceCategorySourceId);
		}

		public virtual IPagedList<ServiceCategorySource> GetAllServiceCategorySources(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
		{
			var query = _serviceCategorySourceRepository.TableNoTracking;

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(sp => sp.Name.Contains(name));

			if (!showHidden)
			{
				query = query.Where(c => c.Published);
			}

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);

			var serviceCategorySources = new PagedList<ServiceCategorySource>(query, pageIndex, pageSize);
			return serviceCategorySources;
		}

		public IList<ServiceInfoSource> GetServices(int serviceCategorySourceId, bool showHidden = false)
		{
			var query = _serviceCategorySourceAndServiceInfoSourceRepository.TableNoTracking.Include(sc => sc.ServiceInfo)
				.Where(sc => sc.ServiceCategorySourceId == serviceCategorySourceId).Select(sc => sc.ServiceInfo);

			if (!showHidden)
			{
				query = query.Where(c => c.Published);
			}

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);


			return query.ToList();
		}

		public virtual void InsertServiceCategorySource(ServiceCategorySource serviceCategorySource)
		{
			if (serviceCategorySource == null)
				throw new ArgumentNullException(nameof(serviceCategorySource));

			_serviceCategorySourceRepository.Insert(serviceCategorySource);
		}

		public virtual void UpdateServiceCategorySource(ServiceCategorySource serviceCategorySource)
		{
			if (serviceCategorySource == null)
				throw new ArgumentNullException(nameof(serviceCategorySource));

			_serviceCategorySourceRepository.Update(serviceCategorySource);
		}
		public virtual void DeleteServiceCategorySource(ServiceCategorySource serviceCategorySource)
		{
			if (serviceCategorySource == null)
				throw new ArgumentNullException(nameof(serviceCategorySource));

			_serviceCategorySourceRepository.Delete(serviceCategorySource);
		}
		#endregion
	}
}