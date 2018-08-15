using ApPetWeb.Models;
using System;

namespace ApPetWeb.Models
{
    public class Pet : Base<int>
    {
        public string Race { get; set; }
        public int Wight { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImageProfileId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PetTypeId { get; set; }
        public PetType PetType { get; set; }
    }
    
}
