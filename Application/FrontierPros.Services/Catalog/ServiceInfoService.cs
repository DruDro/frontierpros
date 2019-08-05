using FrontierPros.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontierPros.Services.Catalog
{
	public partial class ServiceInfoService : IServiceInfoService
	{
        #region Fields

        private readonly IRepository<ServiceInfo> _serviceInfoRepository;
		private readonly IRepository<Category> _categoryRepository;
		private readonly ICategoryService _categoryService;

		#endregion

		#region Ctor

		public ServiceInfoService(IRepository<ServiceInfo> serviceInfoRepository,
			IRepository<Category> categoryRepository,
			ICategoryService categoryService)
        {
            this._serviceInfoRepository = serviceInfoRepository;
			this._categoryRepository = categoryRepository;
			this._categoryService = categoryService;
		}

		#endregion

		#region Methods

		public virtual ServiceInfo GetServiceInfoById(int serviceInfoId, bool includeCategories = false)
		{
			var query = _serviceInfoRepository.Table;
			if (includeCategories)
			{
				query = query.Include("ServiceCategories.ServiceCategory");
			}

			return query.FirstOrDefault(s => s.Id == serviceInfoId);
		}

		public virtual bool IsExistServiceInfo(int serviceInfoId)
		{
			return _serviceInfoRepository.Table.Any(s => s.Id == serviceInfoId && !s.Deleted);
		}

		public virtual ServiceInfo GetServiceInfoByName(string name)
		{
			return _serviceInfoRepository.Table.FirstOrDefault(s => s.Name == name && !s.Deleted);
		}

		public virtual void DeleteServiceInfo(ServiceInfo serviceInfo)
		{
			if (serviceInfo == null)
				throw new ArgumentNullException(nameof(serviceInfo));

			serviceInfo.Deleted = true;
			_serviceInfoRepository.Update(serviceInfo);

			var category = _categoryRepository.GetById(serviceInfo.CategoryId);
			_categoryService.DeleteCategory(category);
		}

		public virtual IPagedList<ServiceInfo> GetAllServiceInfoEntities(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool includeCategories = false, bool showHidden = false)
		{
			var query = _serviceInfoRepository.Table;

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(sp => sp.Name.Contains(name));

			query = query.Where(sp => !sp.Deleted);

			if (!showHidden)
			{
				query = query.Where(c => c.Published);
			}

			if (includeCategories)
			{
				query = query.Include("ServiceCategories.ServiceCategory");
			}

			query = query.Distinct();

			query = query.OrderBy(sp => sp.Name);

			var serviceInfoEntities = new PagedList<ServiceInfo>(query, pageIndex, pageSize);
			return serviceInfoEntities;
        }

		public virtual void InsertServiceInfo(ServiceInfo serviceInfo)
        {
			if (serviceInfo == null)
				throw new ArgumentNullException(nameof(serviceInfo));

			var category = new Category()
			{
				Name = serviceInfo.Name,
				Deleted = serviceInfo.Deleted,
				Published = serviceInfo.Published,
				CreatedOnUtc = DateTime.UtcNow,
				UpdatedOnUtc = DateTime.UtcNow,
				AllowCustomersToSelectPageSize = true,      //default
				PageSizeOptions = "6, 3, 9"                 //default
			};

			_categoryService.InsertCategory(category);

			serviceInfo.CategoryId = category.Id;
			_serviceInfoRepository.Insert(serviceInfo);
        }

		public virtual void UpdateServiceInfo(ServiceInfo serviceInfo)
		{
			if (serviceInfo == null)
				throw new ArgumentNullException(nameof(serviceInfo));

			_serviceInfoRepository.Update(serviceInfo);

			var category = _categoryRepository.GetById(serviceInfo.CategoryId);
			category.Name = serviceInfo.Name;
			category.Deleted = serviceInfo.Deleted;
			category.Published = serviceInfo.Published;

			_categoryService.UpdateCategory(category);
		}

		#endregion
	}
}