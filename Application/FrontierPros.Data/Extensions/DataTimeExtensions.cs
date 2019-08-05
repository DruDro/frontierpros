using NodaTime;
using System;

namespace FrontierPros.Data.Extensions
{
	public static class DataTimeExtensions
	{
		public static DateTime UNIX_TIME = new DateTime(1970, 1, 1, 0, 0, 0);

		public static DateTime ToUtc(this DateTime datetime, string timeZoneId)
		{
			var dtLocal = LocalDateTime.FromDateTime(datetime);
			var dtZoned = dtLocal.InZoneLeniently(DateTimeZoneProviders.Tzdb[timeZoneId]);

			return dtZoned.ToInstant().ToDateTimeUtc();
		}

		public static DateTime ToLocal(this DateTime datetime, string timeZoneId)
		{
			var dtUtc = Instant.FromDateTimeUtc(LocalDateTime.FromDateTime(datetime).InUtc().ToDateTimeUtc());
			var dtZoned = dtUtc.InZone(DateTimeZoneProviders.Tzdb[timeZoneId]);

			return dtZoned.ToDateTimeUnspecified();
		}

		public static double GetUnixTimestamp(DateTime? date)
		{
			return date.Value.Subtract(UNIX_TIME).TotalMilliseconds;
		}

		public static void SetDateRange(ref DateTime? from, ref DateTime? to, string timeZoneId)
		{
			if (from.HasValue && to.HasValue)
			{
				from = from.Value.ToUniversalTime();
				to = to.Value.ToUniversalTime().Date.AddDays(1).AddSeconds(-1);
			}
			else
			{
				from = DateTime.UtcNow.ToLocal(timeZoneId).Date;
				to = DateTime.UtcNow.ToLocal(timeZoneId).Date.AddDays(1).AddSeconds(-1);
			}

			from = from.Value.ToUtc(timeZoneId);
			to = to.Value.ToUtc(timeZoneId);
		}
	}
}
