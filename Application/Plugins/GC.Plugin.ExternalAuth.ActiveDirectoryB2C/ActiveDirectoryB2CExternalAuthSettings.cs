using Nop.Core.Configuration;

namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C
{
    public class ActiveDirectoryB2CExternalAuthSettings : ISettings
    {
		public string Instance { get; set; }
		public string Domain { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string CallbackPath { get; set; }
		public string SignUpSignInPolicyId { get; set; }
		public string ResetPasswordPolicyId { get; set; }
		public string EditProfilePolicyId { get; set; }
    }
}
