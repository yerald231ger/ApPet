
using System.Collections.Generic;

namespace ApPetWeb.Models
{
    public class PetType : Base<int>
    {
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
