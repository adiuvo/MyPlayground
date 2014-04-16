// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The UnitOfWork interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Patterns.Repository.UnitOfWork
{
    using System;

    using MyPlayground.Patterns.Repository.Repositories;

    /// <summary>
    /// TODO The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The begin transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// TODO The commit.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Commit();

        /// <summary>
        /// TODO The dispose.
        /// </summary>
        /// <param name="disposing">
        /// TODO The disposing.
        /// </param>
        void Dispose(bool disposing);

        /// <summary>
        /// TODO The repository.
        /// </summary>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRepository"/>.
        /// </returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;

        /// <summary>
        /// TODO The rollback.
        /// </summary>
        void Rollback();

        /// <summary>
        /// TODO The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int SaveChanges();

        #endregion
    }
}