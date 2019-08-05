using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.Services;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Services
{
	public class ServiceItemMediaFile : BaseEntity
	{
		public string Name { get; set; }
		public MediaType Type { get; set; }
		public string BlobName { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int ServiceItemId { get; set; }
		public virtual ServiceItem ServiceItem { get; set; }
	}
}
