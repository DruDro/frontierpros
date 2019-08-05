using FrontierPros.Core.Domain.Services;
using Nop.Core;
using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Customers
{
	public enum MediaType
	{
		ICON,
		MEDIA
	};

	public class CustomerMediaFile : BaseEntity
	{
		public string Name { get; set; }
		public MediaType Type { get; set; }
		public string BlobName { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
	}
}
