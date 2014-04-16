// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StateHelper.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The state helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Patterns.Repository
{
    using System;
    using System.Data.Entity;

    /// <summary>
    /// TODO The state helper.
    /// </summary>
    public class StateHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The convert state.
        /// </summary>
        /// <param name="state">
        /// TODO The state.
        /// </param>
        /// <returns>
        /// The <see cref="EntityState"/>.
        /// </returns>
        public static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        /// <summary>
        /// TODO The convert state.
        /// </summary>
        /// <param name="state">
        /// TODO The state.
        /// </param>
        /// <returns>
        /// The <see cref="ObjectState"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public static ObjectState ConvertState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Detached:
                    return ObjectState.Unchanged;
                case EntityState.Unchanged:
                    return ObjectState.Unchanged;
                case EntityState.Added:
                    return ObjectState.Added;
                case EntityState.Deleted:
                    return ObjectState.Deleted;
                case EntityState.Modified:
                    return ObjectState.Modified;
                default:
                    throw new ArgumentOutOfRangeException("state");
            }
        }

        #endregion
    }
}