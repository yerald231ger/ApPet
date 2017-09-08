using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApPet.Data;
using ApPet.Models;
using ApPet.Services;

namespace ApPet.Controllers
{
    public class VetServicesController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public VetServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: VetServices
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.VetServices.ReadAsync());
        }

        // GET: VetServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetService = await _unitOfWork.VetServices.ReadAsync(id.Value);
            if (vetService == null)
            {
                return NotFound();
            }

            return View(vetService);
        }

        // GET: VetServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VetServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Price,ShowPrice,Id,Name,UpDate,ModDate,IsActive")] VetService vetService)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VetServices.Create(vetService);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vetService);
        }

        // GET: VetServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetService = await _unitOfWork.VetServices.ReadAsync(id.Value);
            if (vetService == null)
            {
                return NotFound();
            }
            return View(vetService);
        }

        // POST: VetServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Price,ShowPrice,Id,Name,UpDate,ModDate,IsActive")] VetService vetService)
        {
            if (id != vetService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.VetServices.Update(vetService);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VetServiceExists(vetService.Id))
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
            return View(vetService);
        }

        // GET: VetServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetService = await _unitOfWork.VetServices.ReadAsync(id.Value);
            if (vetService == null)
            {
                return NotFound();
            }

            return View(vetService);
        }

        // POST: VetServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vetService = await _unitOfWork.VetServices.ReadAsync(id);
            _unitOfWork.VetServices.Remove(vetService);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VetServiceExists(int id)
        {
            return _unitOfWork.VetServices.Any(id);
        }
    }
}
