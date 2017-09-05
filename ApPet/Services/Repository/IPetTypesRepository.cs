using ApPet.Data;
using ApPet.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApPet.Services
{
    public interface IPetTypeRepository : IRepository<PetType, int>
    {
    }

    public class PetTypeRepository : Repository<PetType, int>, IPetTypeRepository, IDisposable,
    {
        private DbSet<PetType> _dbSet { get; set; }

        public PetTypeRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = _context.Set<PetType>();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}
