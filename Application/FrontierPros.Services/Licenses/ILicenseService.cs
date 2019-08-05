using FrontierPros.Core.Domain.Licenses;
using FrontierPros.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Licenses
{
	public interface ILicenseService
	{
		License GetLicenseById(int licenseId);
		IList<License> GetLicensesByProviderId(int providerId);

		void InsertLicense(License license);
		void UpdateLicense(License license);
		void DeleteLicense(License license);
	}
}
