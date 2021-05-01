using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FEC_APP.Models
{
    public class Aluno
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nome_completo")]
        public string NomeCompleto { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("modalidade")]
        public string Modalidade { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("telefone1")]
        public string Telefone1 { get; set; }

        [JsonProperty("telefone2")]
        public string Telefone2 { get; set; }


        [JsonProperty("reponsavel_id")]
        public long ResponsavelId { get; set; }

        [JsonProperty("docente_id")]
        public long DocenteId { get; set; }

        [JsonProperty("usuario_id")]
        public long UsuarioId { get; set; }
    }
}
