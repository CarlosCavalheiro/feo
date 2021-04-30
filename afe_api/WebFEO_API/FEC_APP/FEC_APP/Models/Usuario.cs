using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.Models
{    
    public class Usuario
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("token")]
        public string TokenRegistrado { get; set; }
    }
}
