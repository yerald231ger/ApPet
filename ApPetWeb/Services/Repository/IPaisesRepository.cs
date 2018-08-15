using ApPetWeb.Models;
using System;

namespace ApPet.Services
{
    public interface IPaisesRepository : IRepository<Pais, int>
    {
    }

    public class PaisesRepository : Repository<Pais, int>, IPaisesRepository, IDisposable
    {
        public PaisesRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = _context.Set<Pais>();
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
