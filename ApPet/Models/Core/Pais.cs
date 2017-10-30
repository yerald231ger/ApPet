using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class Pais : Base<int>
    {
        public Pais()
        {
            Estados = new HashSet<Estado>();
        }

        public string PaisISO { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
