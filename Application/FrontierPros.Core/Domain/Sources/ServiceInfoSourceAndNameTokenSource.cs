using Nop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Core.Domain.Sources
{
	public class ServiceInfoSourceAndNameTokenSource : BaseEntity
	{
		public int NameTokenSourceId { get; set; }
		public virtual NameTokenSource NameToken { get; set; }

		public int ServiceInfoSourceId { get; set; }
		public virtual ServiceInfoSource ServiceInfo { get; set; }

		public bool Enabled { get; set; }
	}
}
