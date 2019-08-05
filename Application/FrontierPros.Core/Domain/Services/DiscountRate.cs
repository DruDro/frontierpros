using Nop.Core;

namespace FrontierPros.Core.Domain.Services
{
	public class DiscountRate : BaseEntity
	{
		public JobScheduleType RecurringSchedule { get; set; }
		public JobDiscountRateType DiscountRateType { get; set; }

		public bool OneMonthDiscountEnabled { get; set; }
		public decimal? OneMonthDiscountValue { get; set; }

		public bool TreeMonthDiscountEnabled { get; set; }
		public decimal? TreeMonthDiscountValue { get; set; }

		public bool SixMonthDiscountEnabled { get; set; }
		public decimal? SixMonthDiscountValue { get; set; }

		public bool TwelveMonthDiscountEnabled { get; set; }
		public decimal? TwelveMonthDiscountValue { get; set; }

		public int ServiceItemId { get; set; }
		public virtual ServiceItem ServiceItem { get; set; }
	}
}
