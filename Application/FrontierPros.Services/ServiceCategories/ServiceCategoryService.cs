using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontierPros.Services.ServiceCategories
{
	public partial class ServiceCategoryService : IServiceCategoryService
	{
        #region Fields

        private readonly IRepository<ServiceCategory> _serviceCategoryRepository;
		private readonly IRepository<ServiceCategoryAndServiceInfo> _serviceCategoryAndServiceInfoRepository;
		#endregion

		#region Ctor

		public ServiceCategoryService(IRepository<ServiceCategory> serviceCategoryRepository,
			IRepository<ServiceCategoryAndServiceInfo> serviceCategoryAndServiceInfoRepository)
        {
            this._serviceCategoryRepository = serviceCategoryRepository;
			this._serviceCategoryAndServiceInfoRepository = serviceCategoryAndServiceInfoRepository;
		}

		#endregion

		#region Methods
		public virtual ServiceCategory GetServiceCategoryById(int serviceCategoryId)
		{
			return _serviceCategoryRepository.GetById(serviceCategoryId);
		}

		public virtual ServiceCategory GetServiceCategoryByName(string name)
		{
			return _serviceCategoryRepository.Table.FirstOrDefault(sc => sc.Name == name);
		}

		public virtual void DeleteServiceCategory(ServiceCategory serviceCategory)
		{
			if (serviceCategory == null)
				throw new ArgumentNullException(nameof(serviceCategory));

			_serviceCategoryRepository.Delete(serviceCategory);
		}

		public virtual IPagedList<ServiceCategory> GetAllServiceCategories(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
		{
			var query = _serviceCategoryRepository.TableNoTracking;

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(sp => sp.Name.Contains(name));

			if (!showHidden)
			{
				query = query.Where(c => c.Published);
			}

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);

			var serviceInfoEntities = new PagedList<ServiceCategory>(query, pageIndex, pageSize);
			return serviceInfoEntities;
		}

		public virtual void InsertServiceCategory(ServiceCategory serviceCategory)
		{
			if (serviceCategory == null)
				throw new ArgumentNullException(nameof(serviceCategory));

			_serviceCategoryRepository.Insert(serviceCategory);
		}

		public virtual void UpdateServiceCategory(ServiceCategory serviceCategory)
		{
			if (serviceCategory == null)
				throw new ArgumentNullException(nameof(serviceCategory));

			_serviceCategoryRepository.Update(serviceCategory);
		}

		public IList<ServiceInfo> GetServices(int serviceCategoryId, bool showHidden = false)
		{
			var query = _serviceCategoryAndServiceInfoRepository.TableNoTracking.Include(sc=>sc.ServiceInfo)
				.Where(sc=>sc.ServiceCategoryId == serviceCategoryId).Select(sc=>sc.ServiceInfo);

			if (!showHidden)
			{
				query = query.Where(c => c.Published);
			}

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);


			return query.ToList();
		}
		#endregion
	}
}