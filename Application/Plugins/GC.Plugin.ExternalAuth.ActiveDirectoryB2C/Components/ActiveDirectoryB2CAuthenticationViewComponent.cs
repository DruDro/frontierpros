using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.ExternalAuth.ActiveDirectoryB2C.Components
{
    [ViewComponent(Name = ActiveDirectoryB2CAuthenticationDefaults.ViewComponentName)]
    public class ActiveDirectoryB2CAuthenticationViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/ExternalAuth.ActiveDirectoryB2C/Views/PublicInfo.cshtml");
        }
    }
}