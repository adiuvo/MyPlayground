namespace MyPlayground.Plumbing.Interfaces
{
    using System;

    /// <summary>
    /// TODO The Registrar interface.
    /// </summary>
    public interface IRegistrar
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
        void Register(Guid id, string text);

        #endregion
    }
}