using ApPet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApPetWeb.Controllers
{
    public class ValuesController : ApiController
    {
        public IPetRepository PetRepository { get; }

        public ValuesController(IPetRepository petRepository) 
        {
            PetRepository = petRepository;
        }

        // GET api/values
        public IEnumerable<string> Get(IPetRepository petRepository)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
