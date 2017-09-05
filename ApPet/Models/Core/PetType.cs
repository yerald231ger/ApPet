using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class PetType : Base<int>
    {
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
