using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrontierPros.Core.Domain.Licenses;
using FrontierPros.Core.Domain.Services;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;

namespace FrontierPros.Services.Licenses
{
	public class LicenseService : ILicenseService
	{
		#region Fields
		private readonly IRepository<License> _licenseRepository;
		#endregion

		#region Ctor

		public LicenseService(IRepository<License> licenseRepository)
		{
			this._licenseRepository = licenseRepository;
		}

		#endregion

		#region Methods
		public License GetLicenseById(int licenseId)
		{
			return _licenseRepository.GetById(licenseId);
		}

		public IList<License> GetLicensesByProviderId(int providerId)
		{
			var query = _licenseRepository.Table;

			query = query.Where(ca => ca.ProviderId == providerId);

			return query.ToList();
		}

		public void InsertLicense(License license)
		{
			if (license == null)
				throw new ArgumentNullException(nameof(license));

			_licenseRepository.Insert(license);
		}

		public void UpdateLicense(License license)
		{
			if (license == null)
				throw new ArgumentNullException(nameof(license));

			_licenseRepository.Update(license);
		}

		public void DeleteLicense(License license)
		{
			if (license == null)
				throw new ArgumentNullException(nameof(license));

			_licenseRepository.Delete(license);
		}
		#endregion

	}
}
