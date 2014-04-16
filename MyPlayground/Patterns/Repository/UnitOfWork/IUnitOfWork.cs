namespace MyPlayground.Patterns.Repository.UnitOfWork
{
    using System;

    using MyPlayground.Patterns.Repository;
    using MyPlayground.Patterns.Repository.Repositories;

    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;
        void BeginTransaction();
        int Commit();
        void Rollback();
    }
}
