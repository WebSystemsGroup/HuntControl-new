using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HuntControl.WebUI.Infrastructure;

namespace HuntControl.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
