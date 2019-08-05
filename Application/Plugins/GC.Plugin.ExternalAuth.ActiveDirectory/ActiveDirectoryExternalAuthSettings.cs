using Nop.Core.Configuration;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory
{
    public class ActiveDirectoryExternalAuthSettings : ISettings
    {
		public string Instance { get; set; }
		public string Domain { get; set; }
		public string TenantId { get; set; }
		public string ClientId { get; set; }
		public string CallbackPath { get; set; }
    }
}
