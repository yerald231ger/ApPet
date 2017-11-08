using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models.XhrViewModels
{
    public class GeographyViewModel
    {
        [Required]
        public double? Latitud { get; set; }
        [Required]
        public double? Longitud { get; set; }
    }
}
