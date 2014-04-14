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
        public LogAspect(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
            Loggers = new Dictionary<Type, ILogger>();
        }

        public ILoggerFactory LoggerFactory { get; set; }

        public Dictionary<Type, ILogger> Loggers { get; set; }

        private static string DumpObject(object argument)
        {
            Type objtype = argument.GetType();
            if (objtype == typeof(String) || objtype.IsPrimitive || !objtype.IsClass)
                return objtype.ToString();

            DataContractSerializer s = new DataContractSerializer(objtype);
            return s.ToString();
        }

        public static String CreateInvocationLogString(IInvocation invocation)
        {
            StringBuilder sb = new StringBuilder(100);
            sb.AppendFormat("Called: {0}.{1}(", invocation.TargetType.Name, invocation.Method.Name);
            foreach (object argument in invocation.Arguments)
            {
                String argumentDescription = argument == null ? "null" : DumpObject(argument);
                sb.Append(argumentDescription).Append(",");
            }
            if (invocation.Arguments.Count() > 0) sb.Length--;
            sb.Append(")");
            return sb.ToString();
        }

        public void Intercept(IInvocation invocation)
        {
            if (!Loggers.ContainsKey(invocation.TargetType))
            {
                Loggers.Add(invocation.TargetType, LoggerFactory.Create(invocation.TargetType));
            }

            ILogger logger = Loggers[invocation.TargetType];
            if (logger.IsDebugEnabled) logger.Debug(CreateInvocationLogString(invocation));
        }
    }
}