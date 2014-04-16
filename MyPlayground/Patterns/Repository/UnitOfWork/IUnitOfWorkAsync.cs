namespace MyPlayground.Patterns.Repository.UnitOfWork
{
    using System.Threading;
    using System.Threading.Tasks;

    using MyPlayground.Patterns.Repository.Repositories;

    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : EntityBase;
        Task<int> CommitAsync();
    }
}