using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Catalog
{
	public class ServiceInfoAndNameToken : BaseEntity
	{
		public int NameTokenId { get; set; }
		public virtual NameToken NameToken { get; set; }

		public int ServiceInfoId { get; set; }
		public virtual ServiceInfo ServiceInfo { get; set; }

		public bool Enabled { get; set; }
	}
}
