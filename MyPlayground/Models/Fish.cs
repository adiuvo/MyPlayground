using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPlayground.Models
{
    using MyPlayground.Patterns.Repository;
    using MyPlayground.Patterns.Repository.Interfaces;
    using MyPlayground.Patterns.Repository.Repositories;
    using MyPlayground.Patterns.Repository.UnitOfWork;


 public class Fish : IUnitOfWork
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

     public void Dispose()
     {
         throw new NotImplementedException();
     }

     public void BeginTransaction()
     {
         throw new NotImplementedException();
     }

     public int Commit()
     {
         throw new NotImplementedException();
     }

     public void Dispose(bool disposing)
     {
         throw new NotImplementedException();
     }

     public IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase
     {
         throw new NotImplementedException();
     }

     public void Rollback()
     {
         throw new NotImplementedException();
     }

     public int SaveChanges()
     {
         throw new NotImplementedException();
     }
    }
}