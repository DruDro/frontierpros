using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrontierPros.Core.Domain.Services;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;

namespace FrontierPros.Services.Services
{
	public class CoverageAreaService : ICoverageAreaService
	{
		#region Fields
		private readonly IRepository<CoverageArea> _coverageAreaRepository;
		#endregion

		#region Ctor

		public CoverageAreaService(IRepository<CoverageArea> coverageAreaRepository)
		{
			this._coverageAreaRepository = coverageAreaRepository;
		}

		#endregion

		#region Methods
		public CoverageArea GetCoverageAreaById(int coverageAreaId)
		{
			return _coverageAreaRepository.GetById(coverageAreaId);
		}

		public IList<CoverageArea> GetCoverageAreasByServiceItemId(int serviceItemId)
		{
			var query = _coverageAreaRepository.Table;

			query = query.Where(ca => ca.ServiceItemId == serviceItemId);

			return query.ToList();
		}

		public void InsertCoverageArea(CoverageArea coverageArea)
		{
			if (coverageArea == null)
				throw new ArgumentNullException(nameof(coverageArea));

			_coverageAreaRepository.Insert(coverageArea);
		}

		public void UpdateCoverageArea(CoverageArea coverageArea)
		{
			if (coverageArea == null)
				throw new ArgumentNullException(nameof(coverageArea));

			_coverageAreaRepository.Update(coverageArea);
		}

		public void DeleteCoverageArea(CoverageArea coverageArea)
		{
			if (coverageArea == null)
				throw new ArgumentNullException(nameof(coverageArea));

			_coverageAreaRepository.Delete(coverageArea);
		}
		#endregion

	}
}
