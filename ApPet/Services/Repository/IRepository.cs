using ApPet.Data;
using ApPet.Models;
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
        EntityEntry<TEntity> Create(TEntity entity);
        Task<EntityEntry<TEntity>> CreateAsync(TEntity entity);
        void Create(ICollection<TEntity> entities);

        ICollection<TEntity> Read();
        Task<ICollection<TEntity>> ReadAsync();
        TEntity Read(TKey key);
        Task<TEntity> ReadAsync(TKey key);

        EntityEntry<TEntity> Update(TEntity entity);
        void Update(ICollection<TEntity> entities);

        EntityEntry<TEntity> Remove(TEntity entity);
        void Remove(ICollection<TEntity> entities);
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        protected ApplicationDbContext _context { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public ICollection<TEntity> Read()
        {
            return _context.Set<TEntity>().Where<TEntity, TKey>().ToList();
        }

        public Task<ICollection<TEntity>> ReadAsync()
        {
            return Task.Factory.StartNew(Read);
        }

        public TEntity Read(TKey key)
        {
            var mentity = _context.Set<TEntity>().Find(key);
            return (mentity != null && mentity.IsActive) ? mentity : null;
        }

        public Task<TEntity> ReadAsync(TKey key)
        {
            return Task.Factory.StartNew(() => Read(key));
        }

        public EntityEntry<TEntity> Create(TEntity entity)
        {
            entity.IsActive = true;
            return _context.Set<TEntity>().Add(entity);
        }

        public Task<EntityEntry<TEntity>> CreateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Create(entity));
        }

        public void Create(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            var _entity = _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return _entity;
        }

        public void Update(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            _context.SaveChanges();
        }

        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            var _entity = _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return _entity;
        }

        public void Remove(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
