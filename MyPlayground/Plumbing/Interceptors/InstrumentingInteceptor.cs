// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstrumentingInteceptor.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The console registrar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Plumbing.Interceptors
{
    using System;

    using MyPlayground.Plumbing.Interfaces;

    /// <summary>
    /// TODO The console registrar.
    /// </summary>
    public class ConsoleRegistrar : IRegistrar
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The register.
        /// </summary>
        /// <param name="id">
        /// TODO The id.
        /// </param>
        /// <param name="text">
        /// TODO The text.
        /// </param>
        public void Register(Guid id, string text)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            Console.WriteLine("{0}\t{1:s}.{2}\t{3}", id, now, now.Millisecond, text);
        }

        #endregion
    }
}