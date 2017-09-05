using ApPet.Data;
using ApPet.Services;
using System;

namespace ApPet.Services
{
    public interface IUnitOfWork
    {
        IPetTypeRepository PetTypes { get; set; }
        int Complete();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IPetTypeRepository PetTypes { get; set; }
        public IPetRepository Pets { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PetTypes = new PetTypeRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
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
