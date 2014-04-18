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
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Castle.Core.Logging;
    using Castle.DynamicProxy;

    /// <summary>
    ///     TODO The log aspect.
    /// </summary>
    public class LogAspect : IInterceptor
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether logging enabled.
        /// </summary>
        public bool LoggingEnabled { get; set; }

        #endregion

        #region Public Methods and Operators

        public static string CreateInvocationLogString(IInvocation invocation)
        {
            var sb = new StringBuilder(100);
            sb.AppendFormat("Called: {0}.{1}(", invocation.TargetType.Name, invocation.Method.Name);
            foreach (object argument in invocation.Arguments)
            {
                String argumentDescription = argument == null ? "null" : DumpObject(argument);
                sb.Append(argumentDescription).Append(",");
            }
            if (invocation.Arguments.Any())
            {
                sb.Length--;
            }
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        ///     The intercept.
        /// </summary>
        /// <param name="invocation">
        ///     The invocation.
        /// </param>
        public void Intercept(IInvocation invocation)
        {
            this.Logger.InfoFormat("{0}::{1}({2})", invocation.TargetType.Name, invocation.Method.Name, string.Join(", ", DumpObject(invocation.Arguments)));

            try
            {
                invocation.Proceed();
            }
            finally
            {
                this.Logger.InfoFormat("Method returned -> {0}::{1}", invocation.TargetType.Name, invocation.ReturnValue);
            }
        }

        #endregion

        #region Methods

        private static string DumpObject(object argument)
        {
            string value;

            Type objtype = argument.GetType();
            if (objtype == typeof(string) || objtype.IsPrimitive || !objtype.IsClass)
            {
                if (objtype.IsClass)
                {
                    value = SerializeObject(argument);
                }
                else
                {
                    value = objtype.ToString();
                }
            }
            else
            {
                value = SerializeObject(argument);
            }

            return value;
        }

        public static string SerializeObject(object toSerialize)
        {
            if (toSerialize == null) return string.Empty;

            var xmlSerializer = new XmlSerializer(toSerialize.GetType());
            var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
        #endregion
    }
}