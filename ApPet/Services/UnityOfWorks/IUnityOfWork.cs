using ApPet.Data;
using System;
using System.Threading.Tasks;

namespace ApPet.Services
{
    public interface IUnitOfWork
    {
        IVetServicesRepository VetServices { get; set; }
        IPetTypeRepository PetTypes { get; set; }
        IPetRepository Pets { get; set; }
        IVeterinaryRepository Veterinaries { get; set; }

        int Complete();
        Task<int> CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IVetServicesRepository VetServices { get; set; }
        public IPetTypeRepository PetTypes { get; set; }
        public IPetRepository Pets { get; set; }
        public IVeterinaryRepository Veterinaries { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PetTypes = new PetTypeRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return Task.Factory.StartNew(Complete);
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
