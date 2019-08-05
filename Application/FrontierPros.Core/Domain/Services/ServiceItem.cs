using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Providers;
using FrontierPros.Core.Domain.TimeZones;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Services
{
	[Flags]
	public enum WorkLocationType
	{
		Worldwide = 0,
		Business = 1,
		Customer = 2,
		BusinessAndCustomer = 3
	};

	[Flags]
	public enum WeekSchedule
	{
		NONE = 0,
		SUN = 1,
		MON = 2,
		TUE = 4,
		WEN = 8,
		THU = 16,
		FRI = 32,
		SAT = 64,
		ALL = 127
	};

	public enum JobScheduleType
	{
		EVERY_DAY,
		WEEKLY,
		BIWEEKLY,
		MONTHLY
	}

	public enum JobDiscountRateType
	{
		PERCENTAGE,
		FIXED
	};

	public class ServiceItem : BaseEntity
	{
		private ICollection<ServiceItemSettings> _settings;
		private ICollection<CoverageArea> _coverageAreas;
		private ICollection<DiscountRate> _discountRates;
		private ICollection<ServiceItemMediaFile> _mediaFiles;

		public string Description { get; set; }

		public bool BasePriceEnabled { get; set; }
		public decimal BasePrice { get; set; }

		public int? IconId { get; set; }
		public virtual ServiceItemMediaFile Icon { get; set; }

		public int? ServiceInfoId { get; set; }
		public virtual ServiceInfo ServiceInfo { get; set; }

		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		public int ProviderId { get; set; }
		public virtual Provider Provider { get; set; }

		public WorkLocationType WorkLocationType { get; set; }

		public bool IsDraft { get; set; }
		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }

		public virtual ICollection<ServiceItemSettings> Settings
		{
			get => _settings ?? (_settings = new List<ServiceItemSettings>());
			protected set => _settings = value;
		}


		public virtual ICollection<CoverageArea> CoverageAreas
		{
			get => _coverageAreas ?? (_coverageAreas = new List<CoverageArea>());
			protected set => _coverageAreas = value;
		}

		//================================================= Business Hours Section
		public WeekSchedule WorkingDaysSchedule { get; set; }

		public TimeSpan BeginHours { get; set; }
		public TimeSpan FinishHours { get; set; }

		public int? TimeZoneDataId { get; set; }
		public virtual TimeZoneData TimeZoneData { get; set; }

		public TimeSpan MinJobDuration { get; set; }

		public TimeSpan JobBookingTime { get; set; }

		public bool IsFlexibleAvailability { get; set; }

		//================================================= Recurring Section
		public bool IsRecurringJob { get; set; }
		public virtual ICollection<DiscountRate> DiscountRates
		{
			get => _discountRates ?? (_discountRates = new List<DiscountRate>());
			protected set => _discountRates = value;
		}

		//================================================= Discount For First Time Customer
		public bool FirstTimeDiscountEnabled { get; set; }
		public decimal FirstTimeDiscountValue { get; set; } //% of base amount

		//================================================= Media Files
		public virtual ICollection<ServiceItemMediaFile> MediaFiles
		{
			get => _mediaFiles ?? (_mediaFiles = new List<ServiceItemMediaFile>());
			protected set => _mediaFiles = value;
		}

	}
}
