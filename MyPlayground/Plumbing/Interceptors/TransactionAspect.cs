// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionAspect.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The transaction aspect.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MyPlayground.Plumbing.Interceptors
{
    using System;

    using Castle.Core.Logging;
    using Castle.DynamicProxy;

    /// <summary>
    ///     TODO The transaction aspect.
    /// </summary>
    public class TransactionAspect : IInterceptor
    {
        #region Public Properties

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
                this.Logger.Info(string.Format("Opening transaction"));
                invocation.Proceed();
                this.Logger.Info(string.Format("Commit"));
            }
            catch (Exception e)
            {
                this.Logger.Info(string.Format("Rollback"));
                throw;
            }
        }

        #endregion
    }
}