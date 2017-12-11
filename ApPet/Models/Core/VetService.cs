using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class VetService : Base<int>
    {
        public string Description { get; set; }
        public float Price { get; set; }
        public bool ShowPrice { get; set; }

        public int IdVeterinary { get; set; }
        public Veterinary Veterinary { get; set; }
    }
}
