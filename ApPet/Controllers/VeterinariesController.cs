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
using Microsoft.Extensions.Configuration;
using ApPet.Models.VeterinariesViewModels;

namespace ApPet.Controllers
{
    public class VeterinariesController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }
        private string ApiKeyGoogle { get; set; }

        public VeterinariesController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            ApiKeyGoogle = configuration["ApiKeyGoogle"];
        }


        // GET: Veterinaries
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Veterinaries.ReadAsync());
        }

        // GET: Veterinaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mveterinary = await _unitOfWork.Veterinaries.ReadAsync(id.Value);
            if (mveterinary == null)
            {
                return NotFound();
            }

            return View(mveterinary);
        }

        // GET: Veterinaries/Create
        public IActionResult Create()
        { 
            ViewBag.ApiKeyGoogle = ApiKeyGoogle;
            return View(new CreateViewModel { Latitud = 25.678, Longitud = 259.678 });
        }

        // POST: Veterinaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,PhoneNumber,Address,Latitud,CP,Longitud,ImageProfileId,Name")] CreateViewModel veterinary)
        {
            ViewBag.ApiKeyGoogle = ApiKeyGoogle;
            if (ModelState.IsValid)
            {
                _unitOfWork.Veterinaries.Create(new Veterinary {
                    Description = veterinary.Description,
                    CP = veterinary.CP,
                    PhoneNumber = veterinary.PhoneNumber.ToString(),
                    Address = veterinary.Address,
                    Latitud = (float)veterinary.Latitud,
                    Longitud = (float)veterinary.Longitud,
                    ImageProfileId = veterinary.ImageProfileId,
                    Name = veterinary.Name
                });
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinary);
        }

        // GET: Veterinaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mveterinary = await _unitOfWork.Veterinaries.ReadAsync(id.Value);
            if (mveterinary == null)
            {
                return NotFound();
            }
            return View(mveterinary);
        }

        // POST: Veterinaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,PhoneNumber,Address,Latitud,Longitud,ImageProfileId,Id,Name,UpDate,ModDate,IsActive")] Veterinary veterinary)
        {
            if (id != veterinary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Veterinaries.Update(veterinary);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinaryExists(veterinary.Id))
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
            return View(veterinary);
        }

        // GET: Veterinaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _unitOfWork.Veterinaries.ReadAsync(id.Value);
            if (veterinary == null)
            {
                return NotFound();
            }

            return View(veterinary);
        }

        // POST: Veterinaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mveterinary = await _unitOfWork.Veterinaries.ReadAsync(id);
            _unitOfWork.Veterinaries.Remove(mveterinary);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinaryExists(int id)
        {
            return _unitOfWork.Veterinaries.Any(id);
        }
    }
}
