using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.ExternalAuth.Twitter.Components
{
    [ViewComponent(Name = TwitterAuthenticationDefaults.ViewComponentName)]
    public class TwitterAuthenticationViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/ExternalAuth.Twitter/Views/PublicInfo.cshtml");
        }
    }
}