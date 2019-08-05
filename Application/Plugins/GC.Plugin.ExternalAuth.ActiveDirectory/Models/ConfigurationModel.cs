using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory.Models
{
    public class ConfigurationModel : BaseNopModel
    {
		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectory.Instance")]
		public string Instance { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectory.Domain")]
		public string Domain { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectory.TenantId")]
		public string TenantId { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectory.ClientId")]
		public string ClientId { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectory.CallbackPath")]
		public string CallbackPath { get; set; }
	}
}