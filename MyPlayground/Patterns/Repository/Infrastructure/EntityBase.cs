// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The entity base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Patterns.Repository
{
    using System.ComponentModel.DataAnnotations.Schema;

    using MyPlayground.Patterns.Repository.Interfaces;

    /// <summary>
    /// TODO The entity base.
    /// </summary>
    public abstract class EntityBase : IObjectState
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the object state.
        /// </summary>
        [NotMapped]
        public ObjectState ObjectState { get; set; }

        #endregion

        // TODO: Renamed since a possible conflict with State entity column
    }
}