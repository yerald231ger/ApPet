using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class Estado : Base<int>
    {
        public int IdPais { get; set; }

        public Pais Pais { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
