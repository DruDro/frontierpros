using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C.Models
{
    public class ConfigurationModel : BaseNopModel
    {
		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.Instance")]
		public string Instance { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.Domain")]
		public string Domain { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientId")]
		public string ClientId { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.ClientSecret")]
		public string ClientSecret { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.CallbackPath")]
		public string CallbackPath { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.SignUpSignInPolicyId")]
		public string SignUpSignInPolicyId { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.ResetPasswordPolicyId")]
		public string ResetPasswordPolicyId { get; set; }

		[NopResourceDisplayName("Plugins.ExternalAuth.ActiveDirectoryB2C.EditProfilePolicyId")]
		public string EditProfilePolicyId { get; set; }
	}
}