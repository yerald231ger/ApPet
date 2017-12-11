using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class Veterinary : Base<int>
    {
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CP { get; set; }
        public string Address { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string ImageProfileId { get; set; }

        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<VetService> Services { get; set; }
    }
}
