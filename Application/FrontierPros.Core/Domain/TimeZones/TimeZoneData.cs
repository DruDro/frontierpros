using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.TimeZones
{
	public class TimeZoneData : BaseEntity
	{
		public string StandardName { get; set; }
		public string TimeZoneId { get; set; }
	}
}
