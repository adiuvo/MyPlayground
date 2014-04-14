using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPlayground.Plumbing.Interceptors
{
    using Castle.Core.Logging;
    using Castle.DynamicProxy;

    public class ExceptionAspect : IInterceptor
    {
        public bool EatAll { get; set; }

        public void Intercept(IInvocation invocation)
        {
        try {
                invocation.Proceed();
            } catch (Exception e) {
                if (!EatAll) {
                    throw;
                }
            }
         }
    }
}