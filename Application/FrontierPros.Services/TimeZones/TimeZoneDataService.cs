using FrontierPros.Core.Domain.TimeZones;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Stores;
using Nop.Services.Catalog;
using Nop.Services.Events;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontierPros.Services.TimeZones
{
	public class TimeZoneDataService : ITimeZoneDataService
	{
		#region Fields
		private readonly IRepository<TimeZoneData> _timeZoneDataRepository;
		#endregion

		#region Ctor

		public TimeZoneDataService(IRepository<TimeZoneData> timeZoneDataRepository,
			IRepository<Store> storeRepository,
			IRepository<StoreMapping> storeMappingRepository,
			IRepository<ProductCategory> productCategoryRepository,
			IStoreService storeService,
			ICategoryService categoryService,
			IStaticCacheManager cacheManager)
		{
			this._timeZoneDataRepository = timeZoneDataRepository;
		}

		#endregion

		#region Methods
		public virtual IList<TimeZoneData> GetAllTimeZoneDataEntities()
		{
			var query = _timeZoneDataRepository.Table;
			var timeZoneDataEntities = query.ToArray();

			var orderedTimeZoneEntities = timeZoneDataEntities.OrderBy(tz => LocalDateTime.FromDateTime(DateTime.Now)
				.InZoneLeniently(DateTimeZoneProviders.Tzdb[tz.TimeZoneId]).Offset).ThenBy(tz => tz.StandardName).ToList();

			return orderedTimeZoneEntities;
		}

		public virtual TimeZoneData GetTimeZoneDataById(int timeZondeDataId)
		{
			return _timeZoneDataRepository.GetById(timeZondeDataId);
		}

		public virtual string GetTimeZoneText(TimeZoneData timeZone)
		{
			return "(GMT " + ((LocalDateTime.FromDateTime(DateTime.Now).InZoneLeniently(
											DateTimeZoneProviders.Tzdb[timeZone.TimeZoneId]).Offset.ToString().Length > 4)
											? LocalDateTime.FromDateTime(DateTime.Now).InZoneLeniently(
												DateTimeZoneProviders.Tzdb[timeZone.TimeZoneId]).Offset.ToString() + ") "
											: LocalDateTime.FromDateTime(DateTime.Now).InZoneLeniently(
												DateTimeZoneProviders.Tzdb[timeZone.TimeZoneId]).Offset.ToString() + ":00) ") +
											timeZone.StandardName;
		}
		#endregion
	}
}
