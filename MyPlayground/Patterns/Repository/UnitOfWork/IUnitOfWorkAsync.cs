// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkAsync.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The UnitOfWorkAsync interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Patterns.Repository.UnitOfWork
{
    using System.Threading;
    using System.Threading.Tasks;

    using MyPlayground.Patterns.Repository.Repositories;

    /// <summary>
    /// TODO The UnitOfWorkAsync interface.
    /// </summary>
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The commit async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> CommitAsync();

        /// <summary>
        /// TODO The repository async.
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRepositoryAsync"/>.
        /// </returns>
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// TODO The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> SaveChangesAsync();

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

        #endregion
    }
}