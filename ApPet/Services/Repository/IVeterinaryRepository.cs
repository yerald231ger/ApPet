using ApPet.Data;
using ApPet.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Services
{
    public interface IVeterinaryRepository : IRepository<Veterinary, int>
    {
        List<Veterinary> SearchNearVeterinaries(double lat, double lng);
    }

    public class VeterinaryRepository : Repository<Veterinary, int>, IVeterinaryRepository, IDisposable
    {
        public VeterinaryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Veterinary> SearchNearVeterinaries(double lat, double lng)
        {
            var vets = _dbSet.FromSql($"EXEC [dbo].[sptblVeterinaries_GetNear]	@Lat = {lat}, @Lng = {lng}").ToList();
            return vets;
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
