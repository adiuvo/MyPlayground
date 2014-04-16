// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogAspect.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The log aspect.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Plumbing.Interceptors
{
    using Castle.Core.Logging;
    using Castle.DynamicProxy;

    /// <summary>
    /// TODO The log aspect.
    /// </summary>
    public class LogAspect : IInterceptor
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether logging enabled.
        /// </summary>
        public bool LoggingEnabled { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The intercept.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        public void Intercept(IInvocation invocation)
        {
            this.Logger.Info(
                string.Format("Method Called -> {0}::{1}", invocation.TargetType.Name, invocation.Method.Name));
            try
            {
                invocation.Proceed();
            }
            finally
            {
                this.Logger.Info(
                    string.Format("Method returned -> {0}::{1}", invocation.TargetType.Name, invocation.Method.Name));
            }
        }

        #endregion
    }
}