// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionAspect.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The exception aspect.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MyPlayground.Plumbing.Interceptors
{
    using System;

    using Castle.Core.Logging;
    using Castle.DynamicProxy;
    using Castle.MicroKernel.Registration;

    /// <summary>
    ///     TODO The exception aspect.
    /// </summary>
    public class ExceptionAspect : IInterceptor
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether eat all.
        /// </summary>
        public bool EatAll { get; set; }

        /// <summary>
        ///     Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// TODO The intercept.
        /// </summary>
        /// <param name="invocation">
        /// TODO The invocation.
        /// </param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                this.Logger.Info(string.Format("{0} caught: {1}", e.GetType(), e.Message));

                if (Dependency.OnAppSettingsValue("HandleExceptions").Equals("false"))
                {
                    throw;
                }

                this.Logger.Info(string.Format("Redirecting to error page"));
            }
        }

        #endregion
    }
}