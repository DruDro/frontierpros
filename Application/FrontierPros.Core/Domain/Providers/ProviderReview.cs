using Nop.Core;
using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Providers
{
	public class ProviderReview : BaseEntity
	{
		public double Rating { get; set; }
		public string Text { get; set; }
		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }

		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		public int ProviderId { get; set; }
		public virtual Provider Provider { get; set; }
	}
}
