namespace MyPlayground.Plumbing.Interceptors
{
    using System;

    using Castle.DynamicProxy;

    using MyPlayground.Plumbing.Interfaces;

    /// <summary>
    /// TODO The instrumenting interceptor.
    /// </summary>
    public class InstrumentingInterceptor : IInterceptor
    {
        #region Fields

        /// <summary>
        /// TODO The registrar.
        /// </summary>
        private readonly IRegistrar registrar;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InstrumentingInterceptor"/> class.
        /// </summary>
        /// <param name="registrar">
        /// TODO The registrar.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public InstrumentingInterceptor(IRegistrar registrar)
        {
            if (registrar == null)
            {
                throw new ArgumentNullException("registrar");
            }

            this.registrar = registrar;
        }

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
            Guid correlationId = Guid.NewGuid();
            this.registrar.Register(
                correlationId, 
                string.Format("{0} begins ({1})", invocation.Method.Name, invocation.TargetType.Name));

            invocation.Proceed();

            this.registrar.Register(
                correlationId, 
                string.Format("{0} ends   ({1})", invocation.Method.Name, invocation.TargetType.Name));
        }

        #endregion
    }
}