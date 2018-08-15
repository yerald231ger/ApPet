//using System.Threading.Tasks;
//using System.Web.Mvc;
//using ApPet.Models;
//using ApPet.Services;
//using ApPetWeb.Models;

//namespace ApPet.Controllers
//{
//    //public class PetTypesController : Controller
//    //{
//    //    private readonly IUnitOfWork _unitOfWork;

//    //    public PetTypesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
//    //    {
//    //        _unitOfWork = unitOfWork;            
//    //    }

//    //    // GET: PetTypes
//    //    public async Task<ViewResult> Index()
//    //    {
//    //        return View(await _unitOfWork.PetTypes.ReadAsync());
//    //    }

//    //    // GET: PetTypes/Details/5
//    //    public async Task<ViewResult> Details(int? id)
//    //    {
//    //        if (id == null)
//    //        {
//    //            //return NotFound();
//    //        }

//    //        var petType = await _unitOfWork.PetTypes.ReadAsync(id.Value);
//    //        if (petType == null)
//    //        {
//    //            //return NotFound();
//    //        }

//    //        return View(petType);
//    //    }

//    //    // GET: PetTypes/Create
//    //    public ViewResult Create()
//    //    {
//    //        return View();
//    //    }

//    //    // POST: PetTypes/Create
//    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    //    [HttpPost]        
//    //    [ValidateAntiForgeryToken]
//    //    public async Task<ViewResult> Create([Bind(Include ="Id,Name,UpDate,ModDate,IsActive")] PetType petType)
//    //    {
//    //        if (ModelState.IsValid)
//    //        {
//    //            var mpetType = await _unitOfWork.PetTypes.CreateAsync(petType);
//    //            _unitOfWork.Complete();
//    //            return RedirectToAction(nameof(Index));
//    //        }
//    //        return View(petType);
//    //    }

//    //    // GET: PetTypes/Edit/5
//    //    public async Task<ViewResult> Edit(int? id)
//    //    {
//    //        if (id == null)
//    //        {
//    //            return NotFound();
//    //        }

//    //        var mpetType = await _unitOfWork.PetTypes.ReadAsync(id.Value);

//    //        if (mpetType == null)
//    //        {
//    //            return NotFound();
//    //        }
//    //        return View(mpetType);
//    //    }

//    //    // POST: PetTypes/Edit/5
//    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//    //    [HttpPost]
//    //    [ValidateAntiForgeryToken]
//    //    public async Task<ViewResult> Edit(int id, [Bind("Id,Name,UpDate,ModDate,IsActive")] PetType petType)
//    //    {
//    //        if (id != petType.Id)
//    //        {
//    //            return NotFound();
//    //        }

//    //        if (ModelState.IsValid)
//    //        {
//    //            try
//    //            {
//    //                _unitOfWork.PetTypes.Update(petType);
//    //                await _unitOfWork.CompleteAsync();
//    //            }
//    //            catch (DbUpdateConcurrencyException)
//    //            {
//    //                if (!PetTypeExists(petType.Id))
//    //                {
//    //                    return NotFound();
//    //                }
//    //                else
//    //                {
//    //                    throw;
//    //                }
//    //            }
//    //            return RedirectToAction(nameof(Index));
//    //        }
//    //        return View(petType);
//    //    }

//    //    // GET: PetTypes/Delete/5
//    //    public async Task<ViewResult> Delete(int? id)
//    //    {
//    //        if (id == null)
//    //        {
//    //            return NotFound();
//    //        }

//    //        var mpetType = await _unitOfWork.PetTypes.ReadAsync(id.Value);
//    //        if (mpetType == null)
//    //        {
//    //            return NotFound();
//    //        }

//    //        return View(mpetType);
//    //    }

//    //    // POST: PetTypes/Delete/5
//    //    [HttpPost, ActionName("Delete")]
//    //    [ValidateAntiForgeryToken]
//    //    public async Task<ViewResult> DeleteConfirmed(int id)
//    //    {
//    //        var mpetType = await _unitOfWork.PetTypes.ReadAsync(id);
//    //        var mentity = _unitOfWork.PetTypes.Remove(mpetType, false);
//    //        await _unitOfWork.CompleteAsync();
//    //        return RedirectToAction(nameof(Index));
//    //    }

//    //    private bool PetTypeExists(int id)
//    //    {
//    //        return _unitOfWork.PetTypes.Any(id);
//    //    }
//    //}
//}
