// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataContext.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The DataContext interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Patterns.Repository.Interfaces
{
    using System;
    using System.Data.Entity;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// TODO The DataContext interface.
    /// </summary>
    public interface IDataContext : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// TODO The set.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbSet"/>.
        /// </returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// TODO The sync object state.
        /// </summary>
        /// <param name="entity">
        /// TODO The entity.
        /// </param>
        void SyncObjectState(object entity);

        #endregion
    }

    /// <summary>
    /// TODO The DataContextAsync interface.
    /// </summary>
    public interface IDataContextAsync : IDataContext
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The save changes async.
        /// </summary>
        /// <param name="cancellationToken">
        /// TODO The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// TODO The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> SaveChangesAsync();

        #endregion
    }
}