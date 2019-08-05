using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Services
{

	public class ServiceInfoFilterModel : PageModel	{
		public string Name { get; set; }
		public bool IncludeCategories { get; set; }
	}
}
