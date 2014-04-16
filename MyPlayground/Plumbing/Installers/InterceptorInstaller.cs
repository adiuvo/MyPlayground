// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterceptorInstaller.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The interceptor installer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MyPlayground.Plumbing.Interceptors;

    /// <summary>
    /// TODO The interceptor installer.
    /// </summary>
    public class InterceptorInstaller : IWindsorInstaller
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The install.
        /// </summary>
        /// <param name="container">
        /// TODO The container.
        /// </param>
        /// <param name="store">
        /// TODO The store.
        /// </param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register the logger
            container.Register(
                Component.For<LogAspect>()
                    //.DependsOn(Property.ForKey("EatAll").Equals("true"))
                    .LifestyleTransient());

            // Register the Exception handler
            container.Register(
                Component.For<ExceptionAspect>()
                .DependsOn(Property.ForKey("EatAll").Equals("true"))
                    .LifestyleTransient());
        }

        #endregion
    }
}