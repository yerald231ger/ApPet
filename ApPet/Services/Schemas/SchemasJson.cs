using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Services.Schemas
{
    public class JsonSchemas
    {
        public AccountSchemas AccountSchemas { get; set; }
    }

    public class AccountSchemas
    {
        public string signIn { get; set; }
        public string logIn { get; set; }
    }    
}
