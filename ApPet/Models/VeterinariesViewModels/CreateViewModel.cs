using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models.VeterinariesViewModels
{
    public class CreateViewModel
    {
        public string Description { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string CP { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ImageProfileId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }
    }
}
