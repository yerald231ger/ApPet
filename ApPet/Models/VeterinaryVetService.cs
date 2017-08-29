using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class VeterinaryVetService
    {
        public int VeterinaryId { get; set; }
        public Veterinary Veterinary { get; set; }

        public int VetServiceId { get; set; }
        public VetService VetService { get; set; }
    }
}
