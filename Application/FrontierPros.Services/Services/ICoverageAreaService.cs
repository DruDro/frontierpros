using FrontierPros.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Services
{
	public interface ICoverageAreaService
	{
		CoverageArea GetCoverageAreaById(int coverageAreaId);
		IList<CoverageArea> GetCoverageAreasByServiceItemId(int serviceItemId);

		void InsertCoverageArea(CoverageArea coverageArea);
		void UpdateCoverageArea(CoverageArea coverageArea);
		void DeleteCoverageArea(CoverageArea coverageArea);
	}
}
