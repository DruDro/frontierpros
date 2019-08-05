using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.ExternalAuth.Twitter.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.ExternalAuth.Twitter.ConsumerKey")]
        public string ConsumerKey { get; set; }

        [NopResourceDisplayName("Plugins.ExternalAuth.Twitter.ConsumerSecret")]
        public string ConsumerSecret { get; set; }
    }
}