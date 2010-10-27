using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using FeatureDBWrapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace Marcusoft.OutsideIn.FeatureDemo.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            RegisterAllControllersIn(Assembly.GetExecutingAssembly());
        }
        
        protected override IKernel CreateKernel() {
            return Container;
        }

        internal class SiteModule : NinjectModule {
            public override void Load() {
                Bind<IFeatureDBWrapper>().To<InMemoryFeatureDBWrapper>();
            }
        }

        static readonly IKernel _container =  new StandardKernel(new SiteModule());
        public static IKernel Container
        {
            get { return _container; }
        }
    }
}