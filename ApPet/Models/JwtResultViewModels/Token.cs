using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class Token : JwtResult
    {
        public string token { get; set; }
        public int expires { get; set; }
    }

    public class JwtErros : JwtResult
    {
        public List<JwtError> errors { get; set; }

        public class JwtError
        {
            public string param { get; set; }
            public string error { get; set; }
        }
    }


    public class JwtResult
    {
        public bool ok { get; set; }
    }
}
