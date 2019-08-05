using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Data
{
	public static class ScalarFunctionsHelpers
	{
		#region Functions
		[DbFunction("getDistance", "dbo")]
		public static double GetDistance(double lat1, double long1, double lat2, double long2)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
