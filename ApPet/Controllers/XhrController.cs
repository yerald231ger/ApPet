using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApPet.Models;
using System.Collections.Generic;
using ApPet.Services;

namespace ApPet.Controllers
{
    [Route("xhr")]
    [Produces("application/json")]
    [Authorize]
    public class XhrController : Controller
    {
        private IVeterinaryRepository veterinaryRepository;

        public XhrController(IVeterinaryRepository veterinaryRepository) {
            this.veterinaryRepository = veterinaryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<Veterinary> GetNearVeterinaries(double lat, double lng)
        {
            List<Veterinary> listVeterinaries = veterinaryRepository.Search(lat, lng);
            return null;
        }

        [HttpGet]
        public string GetGeoLocalization(string Address) {

            return "";
        }        
    }
}