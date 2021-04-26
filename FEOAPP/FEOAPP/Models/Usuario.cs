using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FEOAPP.Models
{
    class Usuario
    {

        [JsonProperty("id")]
        public long Id { get; set; }


        [Required(ErrorMessage = "O campo [Usuário] é obrigatório")]
        [JsonProperty("usuario")]
        public string Login { get; set; }


        [Required(ErrorMessage = "O campo [Senha] é obrigatório")]
        [JsonProperty("senha")]
        public string Senha { get; set; }


        [DisplayName("TIPO")]
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        
        [JsonProperty("token")]
        public string Token { get; set; }

        
        [JsonProperty("token_validade")]
        public DateTime TokenValidade { get; set; }


    }
}
