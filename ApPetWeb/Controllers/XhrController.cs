//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using ApPet.Services;
//using ApPet.Models;
//using ApPet.Models.XhrViewModels;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

//namespace ApPet.Controllers
//{
//    [Route("xhr")]
//    [Authorize(AuthenticationSchemes =
//    JwtBearerDefaults.AuthenticationScheme)]
//    [Produces("application/json")]
//    public class XhrController : Controller
//    {
//        private IVeterinaryRepository veterinaryRepository;

//        public XhrController(IVeterinaryRepository veterinaryRepository)
//        {
//            this.veterinaryRepository = veterinaryRepository;
//        }
        
//        [HttpGet("Vets/{latitud:double}/{longitud:double}")]
//        public List<Veterinary> GetVeterinaries(GeographyViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                List<Veterinary> listVeterinaries = veterinaryRepository.SearchNearVeterinaries(model.Latitud.Value, model.Longitud.Value);
//                return listVeterinaries;
//            }
//            return new List<Veterinary>();
//        }

//        [HttpGet]
//        public string GetGeoLocalization(string Address)
//        {

//            return "";
//        }
//    }
//}