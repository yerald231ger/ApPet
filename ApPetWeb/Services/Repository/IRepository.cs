using ApPetWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Services
{
    public interface IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        //Create Methods
        TEntity Create(TEntity entity);
        void Create(ICollection<TEntity> entities);
        Task<TEntity> CreateAsync(TEntity entity); //Async

        //Read Methods
        ICollection<TEntity> Read();
        TEntity Read(TKey key);
        Task<ICollection<TEntity>> ReadAsync(); //Async
        Task<TEntity> ReadAsync(TKey key); //Async

        //Update Methods
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity); //Async
        void Update(ICollection<TEntity> entities);

        //Remove Methods
        TEntity Remove(TEntity entity, bool softDelete = true);
        TEntity Remove(TKey key, bool softDelete = true);
        Task<TEntity> RemoveAsync(TEntity key, bool softDelete = true); //Async
        Task<TEntity> RemoveAsync(TKey key, bool softDelete = true); //Async
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

        public TEntity Create(TEntity entity)
        {
            entity.IsActive = true;
            entity.ModDate = DateTime.Now;
            entity.UpDate = DateTime.Now;
            return _dbSet.Add(entity);
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Create(entity));
        }

        public void Create(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            entity.ModDate = DateTime.Now;
            //return _dbSet.Update(entity);
            return null;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() => Update(entity));
        }

        public void Update(ICollection<TEntity> entities)
        {
            //_dbSet.UpdateRange(entities);
        }

        public TEntity Remove(TEntity entity, bool softDelete = true)
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

        public TEntity Remove(TKey key, bool softDelete = true)
        {
            var mentity = Read(key);
            return Remove(mentity, softDelete);
        }
        
        public Task<TEntity> RemoveAsync(TEntity entity, bool softDelete = true)
        {
            return Task.Factory.StartNew(() => Remove(entity, softDelete));
        }

        public Task<TEntity> RemoveAsync(TKey key, bool softDelete = true)
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
