using ApPet.Data;
using ApPet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApPet.Services
{
    public interface IPetRepository : IRepository<Pet, int>
    {
    }

    public class PetRepository : Repository<Pet, int>, IPetRepository, IDisposable
    {
        private DbSet<Pet> _dbSet { get; set; }

        public PetRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = _context.Set<Pet>();
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
