using ApPet.Models;
using ApPetWeb.Models;
using System;

namespace ApPet.Services
{
    public interface IVetServicesRepository : IRepository<VetService, int>
    {
    }

    public class VetServicesRepository : Repository<VetService, int>, IVetServicesRepository, IDisposable
    {
        public VetServicesRepository(ApplicationDbContext context) : base(context)
        {
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
