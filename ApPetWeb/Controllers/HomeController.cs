using ApPet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApPetWeb.Controllers
{
    public class HomeController : Controller
    {
        public IPaisesRepository PaisesRepository { get; }

        public HomeController(IPaisesRepository paisesRepository)
        {
            PaisesRepository = paisesRepository;
        }

        public ActionResult Index()
        {
            var p = PaisesRepository.Read();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
