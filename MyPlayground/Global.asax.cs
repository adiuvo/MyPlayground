// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The mvc application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using MyPlayground.Plumbing.Factories;

    /// <summary>
    /// TODO The mvc application.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        #region Static Fields

        /// <summary>
        /// TODO The container.
        /// </summary>
        private static IWindsorContainer container;

        #endregion

        #region Methods

        /// <summary>
        /// TODO The application_ end.
        /// </summary>
        protected void Application_End()
        {
            container.Dispose();
        }

        /// <summary>
        /// TODO The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapEditorTemplatesConfig.RegisterBundles();

            BootstrapContainer();
        }

        /// <summary>
        /// TODO The bootstrap container.
        /// </summary>
        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            container.Register(Classes
                .FromAssemblyInThisApplication()
                .InNamespace("MyPlayground.Plumbing")
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        #endregion
    }
}