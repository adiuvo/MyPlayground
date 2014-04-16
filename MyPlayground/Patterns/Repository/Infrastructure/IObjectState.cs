// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectState.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The ObjectState interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Patterns.Repository.Interfaces
{
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPlayground.Patterns.Repository;

    /// <summary>
    /// TODO The ObjectState interface.
    /// </summary>
    public interface IObjectState
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the object state.
        /// </summary>
        [NotMapped]
        ObjectState ObjectState { get; set; }

        #endregion
    }
}