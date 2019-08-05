using System;
using System.Collections.Generic;
using System.Linq;
using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Services;
using FrontierPros.Data;
using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;

namespace FrontierPros.Services.Services
{
	public class ServiceItemService : IServiceItemService
	{
		#region Fields
		private readonly IRepository<ServiceItem> _serviceItemRepository;
		private readonly IRepository<ServiceInfo> _serviceInfoRepository;
		private readonly IProductService _productService;

		#endregion

		#region Ctor

		public ServiceItemService(IRepository<ServiceItem> serviceItemRepository,
			IRepository<ServiceInfo> serviceInfoRepository,
			IProductService productService)
		{
			this._serviceItemRepository = serviceItemRepository;
			this._serviceInfoRepository = serviceInfoRepository;
			this._productService = productService;
		}

		#endregion

		#region Methods
		public virtual IList<ServiceItem> GetServiceItemsByProviderId(int providerId)
		{
			var query = _serviceItemRepository.Table;

			query = query.Where(s => s.ProviderId == providerId);

			return query.ToList();
		}

		public virtual IList<ServiceItem> GetAllServiceItems(string searchTerm,
															int? serviceCategoryId = null,
															int? serviceInfoId = null, 
															WorkLocationType? workLocationType = null,
															double? latitude = null,
															double? longitude = null,
															double? distanceTravel = null,
															int pageIndex = 0, 
															int pageSize = int.MaxValue)
		{
			var query = _serviceItemRepository.Table;

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				query = query.Where(s => s.ServiceInfo.Name.Contains(searchTerm));
			}

			if (serviceInfoId.HasValue)
			{
				query = query.Where(s => s.ServiceInfoId == serviceInfoId.Value);
			}
			else if(serviceCategoryId.HasValue)
			{
				query = query.Where(s => s.ServiceInfo.ServiceCategories.Any(sc=>sc.ServiceCategoryId == serviceCategoryId.Value));
			}

			if (workLocationType.HasValue)
			{
				if (workLocationType == WorkLocationType.Worldwide || workLocationType == WorkLocationType.BusinessAndCustomer)
				{
					query = query.Where(s => s.WorkLocationType == workLocationType.Value);
				}
				else
				{
					query = query.Where(s => s.WorkLocationType == workLocationType.Value || s.WorkLocationType == WorkLocationType.BusinessAndCustomer);
				}

				if (distanceTravel.HasValue && latitude.HasValue && longitude.HasValue)
				{
					if(workLocationType == WorkLocationType.Business)
					{
						query = query.Where(s => s.CoverageAreas.Any(area => area.IsServiceLocation && ScalarFunctionsHelpers.GetDistance(area.Latitude, area.Longitude, latitude.Value, longitude.Value) <= distanceTravel.Value));
					}
					else if(workLocationType == WorkLocationType.Customer)
					{
						query = query.Where(s => s.CoverageAreas.Any(area => ScalarFunctionsHelpers.GetDistance(area.Latitude, area.Longitude, latitude.Value, longitude.Value) <= area.DistanceTravel));
					}else if(workLocationType == WorkLocationType.BusinessAndCustomer)
					{
						query = query.Where(s => s.CoverageAreas.Any(area => ScalarFunctionsHelpers.GetDistance(area.Latitude, area.Longitude, latitude.Value, longitude.Value) <= distanceTravel.Value) 
						|| s.CoverageAreas.Any(area => ScalarFunctionsHelpers.GetDistance(area.Latitude, area.Longitude, latitude.Value, longitude.Value) <= area.DistanceTravel));
					}
				}
			}

			query = query.OrderBy(s => s.Id);

			var serviceItems = new PagedList<ServiceItem>(query, pageIndex, pageSize);
			return serviceItems;
		}

		public virtual ServiceItem GetServiceItemById(int serviceItemId)
		{
			return _serviceItemRepository.Table
				.Include(s=>s.CoverageAreas)
				.Include(s=>s.DiscountRates)
				.Include(s=>s.Icon)
				.Include(s=>s.MediaFiles)
				.Include(s=>s.Settings)
				.FirstOrDefault(s=>s.Id == serviceItemId);
		}

		public virtual void InsertServiceItem(ServiceItem serviceItem)
		{
			if (serviceItem == null)
				throw new ArgumentNullException(nameof(serviceItem));

			var product = new Product(){
				Name = string.Empty,
				CreatedOnUtc = serviceItem.CreatedOnUtc,
				UpdatedOnUtc = serviceItem.UpdatedOnUtc
			};

			_productService.InsertProduct(product);

			serviceItem.ProductId = product.Id;
			_serviceItemRepository.Insert(serviceItem);
		}

		public virtual void UpdateServiceItem(ServiceItem serviceItem)
		{
			if (serviceItem == null)
				throw new ArgumentNullException(nameof(serviceItem));

			_serviceItemRepository.Update(serviceItem);

			var product = _productService.GetProductById(serviceItem.ProductId);

			product.CreatedOnUtc = serviceItem.CreatedOnUtc;
			product.UpdatedOnUtc = serviceItem.UpdatedOnUtc;
			//TODO:product fields to update

			_productService.UpdateProduct(product);
		}
		public virtual void DeleteServiceItem(ServiceItem serviceItem)
		{
			if (serviceItem == null)
				throw new ArgumentNullException(nameof(serviceItem));

			var product = _productService.GetProductById(serviceItem.ProductId);
			_productService.DeleteProduct(product);
		}
		#endregion

	}
}
