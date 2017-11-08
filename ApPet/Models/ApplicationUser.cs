﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ApPet.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime UpDate { get; set; }
        public DateTime ModDate { get; set; }
        
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
