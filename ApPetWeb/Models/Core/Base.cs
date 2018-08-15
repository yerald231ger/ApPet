using System;

namespace ApPetWeb.Models
{
    public class Base<TKey> 
    {
        public TKey Id { get; set; }
        public string Nombre { get; set; }
        public DateTime UpDate { get; set; }
        public DateTime ModDate { get; set; }
        public bool IsActive { get; set; }        
    }
}
