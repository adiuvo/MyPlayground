using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace MyPlayground.Plumbing.Interceptors
{
    using System.Text;

    using Castle.Core.Logging;
    using Castle.DynamicProxy;

    public class LogAspect : IInterceptor
    {
        /// <summary>
        /// Gets or sets a value indicating whether eat all.
        /// </summary>
        public bool EatAll { get; set; }

        public bool LoggingEnabled { get; set; }

        /// <summary>
        /// The intercept.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                string.Format("Method Called -> {0}::{1}", invocation.TargetType.Name, invocation.Method.Name);
                invocation.Proceed();
                string.Format("Method returned -> {0}::{1}", invocation.TargetType.Name, invocation.Method.Name);
            }
            catch (Exception e)
            {
                string.Format("{0} caught: {1}", e.GetType(), e.Message);
                if (!this.EatAll)
                {
                    throw;
                }
            }
        }
    }
}