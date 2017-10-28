using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApPet.Controllers
{
    public class XhrController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}