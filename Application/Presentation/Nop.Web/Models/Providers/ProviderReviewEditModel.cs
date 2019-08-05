using FrontierPros.Core.Domain.Services;
using Nop.Core.Domain.Catalog;
using System;

namespace Nop.Web.Models.Providers
{
	public class ProviderReviewEditModel
	{
		public int Id { get; set; }
		public double Rating { get; set; }
		public string Text { get; set; }
	}
}