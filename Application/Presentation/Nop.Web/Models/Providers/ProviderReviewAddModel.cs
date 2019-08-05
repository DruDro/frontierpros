using FrontierPros.Core.Domain.Services;
using Nop.Core.Domain.Catalog;
using System;

namespace Nop.Web.Models.Providers
{
	public class ProviderReviewAddModel
	{
		public double Rating { get; set; }
		public string Text { get; set; }
		public int ProviderId { get; set; }
	}
}