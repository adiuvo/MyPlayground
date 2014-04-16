using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPlayground.Plumbing.Selectors
{
    using Castle.Core;
    using Castle.MicroKernel.Proxy;

    using MyPlayground.Plumbing.Interceptors;

    public class InterceptorSelector : IModelInterceptorsSelector
    {
        public bool HasInterceptors(ComponentModel model)
        {
            return typeof(LogAspect) != model.Implementation
                   && model.Implementation.Namespace.StartsWith("MyPlayground");
        }

        public InterceptorReference[] SelectInterceptors(ComponentModel model, InterceptorReference[] interceptors)
        {
            return new[]
                       {
                           InterceptorReference.ForType<LogAspect>(), 
                           InterceptorReference.ForType<ExceptionAspect>()
                       };
        }
    }
}