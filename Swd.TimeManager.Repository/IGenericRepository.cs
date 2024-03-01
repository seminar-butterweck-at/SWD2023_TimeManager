using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        DbSet<TEntity> DbSet { get; }

        //CRUD Create - Read - Update - Delete
        //Create Methoden
        void Add(TEntity t);
        Task AddAsync(TEntity t);

        //Read Methoden
        IQueryable<TEntity> ReadAll();
        Task<IQueryable<TEntity>> ReadAllAsync();
        TEntity ReadByKey(object key);


        //Update Methoden
        void Update(TEntity t, object key);


        //Delete Methoden
        void Delete(object key);


    }
}
