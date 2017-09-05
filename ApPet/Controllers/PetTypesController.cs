using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApPet.Data;
using ApPet.Models;
using ApPet.Services;

namespace ApPet.Controllers
{
    public class PetTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PetTypesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;            
        }

        // GET: PetTypes
        public async Task<IActionResult> Index()
        {
            //return View(await _context.PetTypes.ToListAsync());
            return View(await _unitOfWork.PetTypes.ReadAsync());
        }

        // GET: PetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petType = await _context.PetTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (petType == null)
            {
                return NotFound();
            }

            return View(petType);
        }

        // GET: PetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UpDate,ModDate,IsActive")] PetType petType)
        {
            if (ModelState.IsValid)
            {
                var mpetType = await _unitOfWork.PetTypes.CreateAsync(petType);
                _unitOfWork.Complete();
                //_context.Add(petType);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petType);
        }

        // GET: PetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mpetType = await _unitOfWork.PetTypes.ReadAsync(id.Value);
            //var petType = await _context.PetTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (mpetType == null)
            {
                return NotFound();
            }
            return View(mpetType);
        }

        // POST: PetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UpDate,ModDate,IsActive")] PetType petType)
        {
            if (id != petType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetTypeExists(petType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(petType);
        }

        // GET: PetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petType = await _context.PetTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (petType == null)
            {
                return NotFound();
            }

            return View(petType);
        }

        // POST: PetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petType = await _context.PetTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetTypeExists(int id)
        {
            return _context.PetTypes.Any(e => e.Id == id);
        }
    }
}
