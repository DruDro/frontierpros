using FrontierPros.Core.Domain.TimeZones;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.TimeZones
{
	public interface ITimeZoneDataService
	{
		IList<TimeZoneData> GetAllTimeZoneDataEntities();

		TimeZoneData GetTimeZoneDataById(int timeZoneDataId);

		string GetTimeZoneText(TimeZoneData timeZone);
	}
}
