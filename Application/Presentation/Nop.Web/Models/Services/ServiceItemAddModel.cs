using FrontierPros.Core.Domain.Services;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Web.Models.Services
{
	public class ServiceItemAddModel
	{
		public int ServiceInfoId { get; set; }
		public string Description { get; set; }
		public WorkLocationType WorkLocationType { get; set; }

		public decimal BasePrice { get; set; }

		public WeekSchedule WorkingDaysSchedule { get; set; }
		public TimeSpan BeginHours { get; set; }
		public TimeSpan FinishHours { get; set; }
		public int? TimeZoneDataId { get; set; }
		public TimeSpan MinJobDuration { get; set; }
		public TimeSpan JobBookingTime { get; set; }
		public bool IsFlexibleAvailability { get; set; }

		public bool FirstTimeDiscountEnabled { get; set; }
		public decimal FirstTimeDiscountValue { get; set; }

		public bool IsRecurringJob { get; set; }
		public List<DiscountRateModel> DiscountRates { get; set; }
	}
}