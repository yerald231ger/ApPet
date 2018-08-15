using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models.VetServicesViewModels
{
    public class CreateViewModel
    {
        public int IdVeterinary { get; set; }
        public float Price { get; set; }
        public bool ShowPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
