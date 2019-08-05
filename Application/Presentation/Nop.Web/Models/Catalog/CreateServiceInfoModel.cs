using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Web.Models.Catalog
{
	public class CreateServiceInfoModel
	{
		public string Name { get; set; }
		public List<int> ServiceCategoryIds { get; set; } = new List<int>();
	}
}