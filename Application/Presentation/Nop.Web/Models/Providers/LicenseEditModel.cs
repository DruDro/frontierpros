using FrontierPros.Core.Domain.Services;
using Nop.Core.Domain.Catalog;
using System;

namespace Nop.Web.Models.Providers
{
	public class LicenseEditModel
	{
		public int Id { get; set; }
		public string State { get; set; }
		public string LicenseType { get; set; }
		public string LicenseNumber { get; set; }
		public int ProviderId { get; set; }
	}
}