using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebFEO_API.Models
{
    public class Responsavel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nomeCompleto")]
        public string NomeCompleto { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

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


        [JsonProperty("usuarioId")]
        public long UsuarioId { get; set; }


        internal AppDb Db { get; set; }

        public Responsavel()
        {
        }

        internal Responsavel(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `t_responsavel` (`nome_completo`, `foto`, `cep`,`endereco`,`numero`,`bairro`,`cidade`,`estado`,`telefone1`,`telefone2`,`t_usuario_id`) VALUES (@nome_completo, @foto, @cep, @endereco, @numero, @bairro, @cidade, @estado, @telefone1, @telefone2, @t_usuario_id);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `t_responsavel` SET `nome_completo` = @nome_completo, `foto` = @foto, `cep` = @cep , `endereco` = @endereco, `numero` = @numero , `bairro` = @bairro, `cidade` = @cidade, `estado` = @estado,`telefone1` = @telefone1, `telefone2` = @telefone2, `t_usuario_id` = @t_usuario_id WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_responsavel` WHERE `Id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@nome_completo",
                DbType = DbType.String,
                Value = NomeCompleto,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@foto",
                DbType = DbType.String,
                Value = Foto,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@cep",
                DbType = DbType.String,
                Value = CEP,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@endereco",
                DbType = DbType.String,
                Value = Endereco,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@numero",
                DbType = DbType.String,
                Value = Numero,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@bairro",
                DbType = DbType.String,
                Value = Bairro,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@cidade",
                DbType = DbType.String,
                Value = Cidade,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@estado",
                DbType = DbType.String,
                Value = Estado,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@telefone1",
                DbType = DbType.String,
                Value = Telefone1,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@telefone2",
                DbType = DbType.String,
                Value = Telefone2,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@t_usuario_id",
                DbType = DbType.Int32,
                Value = UsuarioId,
            });


        }
    }
}
