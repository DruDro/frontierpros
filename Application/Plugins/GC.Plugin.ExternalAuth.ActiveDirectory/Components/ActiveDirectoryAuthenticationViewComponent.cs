using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.ExternalAuth.ActiveDirectory.Components
{
    [ViewComponent(Name = ActiveDirectoryAuthenticationDefaults.ViewComponentName)]
    public class ActiveDirectoryAuthenticationViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/ExternalAuth.ActiveDirectory/Views/PublicInfo.cshtml");
        }
    }
}