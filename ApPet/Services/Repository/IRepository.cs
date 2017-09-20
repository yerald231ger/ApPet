using ApPet.Data;
using ApPet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApPet.Services
{
    public interface IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        //Create Methods
        EntityEntry<TEntity> Create(TEntity entity);
        void Create(ICollection<TEntity> entities);
        Task<EntityEntry<TEntity>> CreateAsync(TEntity entity); //Async

        //Read Methods
        ICollection<TEntity> Read();
        TEntity Read(TKey key);
        Task<ICollection<TEntity>> ReadAsync(); //Async
        Task<TEntity> ReadAsync(TKey key); //Async

        //Update Methods
        EntityEntry<TEntity> Update(TEntity entity);
        Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity); //Async
        void Update(ICollection<TEntity> entities);

        //Remove Methods
        EntityEntry<TEntity> Remove(TEntity entity, bool softDelete = true);
        EntityEntry<TEntity> Remove(TKey key, bool softDelete = true);
        Task<EntityEntry<TEntity>> RemoveAsync(TEntity key, bool softDelete = true); //Async
        Task<EntityEntry<TEntity>> RemoveAsync(TKey key, bool softDelete = true); //Async
        void Remove(ICollection<TEntity> entities);

        //Search Methods
        TEntity Search(string expression);

        // Any Method
        bool Any(TKey key);

        int Complete();
        Task<int> CompleteAsync();
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        protected ApplicationDbContext _context { get; set; }
        protected DbSet<TEntity> _dbSet { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public ICollection<TEntity> Read()
        {
            return _dbSet.Where<TEntity, TKey>().ToList();
        }

        public Task<ICollection<TEntity>> ReadAsync()
        {
            return Task.Factory.StartNew(Read);
        }

        public TEntity Read(TKey key)
        {
            var mentity = _dbSet.Find(key);
            return (mentity != null && mentity.IsActive) ? mentity : null;
        }

        public Task<TEntity> ReadAsync(TKey key)
        {
            return Task.Factory.StartNew(() => Read(key));
        }

        public EntityEntry<TEntity> Create(TEntity entity)
        {
            entity.IsActive = true;
            return _dbSet.Add(entity);
        }

        public Task<EntityEntry<TEntity>> CreateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Create(entity));
        }

        public void Create(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            entity.ModDate = DateTime.Now;
            return _dbSet.Update(entity);
        }

        public Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Update(entity));
        }

        public void Update(ICollection<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public EntityEntry<TEntity> Remove(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.IsActive = false;
                return Update(entity);
            }
            else
            {
                return _dbSet.Remove(entity);
            }
        }

        public EntityEntry<TEntity> Remove(TKey key, bool softDelete = true)
        {
            var mentity = Read(key);
            return Remove(mentity, softDelete);
        }
        
        public Task<EntityEntry<TEntity>> RemoveAsync(TEntity entity, bool softDelete = true)
        {
            return Task.Factory.StartNew(() => Remove(entity, softDelete));
        }

        public Task<EntityEntry<TEntity>> RemoveAsync(TKey key, bool softDelete = true)
        {
            return Task.Factory.StartNew(() => Remove(key, softDelete));
        }

        public void Remove(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return Task.Factory.StartNew(Complete);
        }

        public bool Any(TKey key)
        {
            return _dbSet.Any(e => e.Id.Equals(key));
        }

        public TEntity Search(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
