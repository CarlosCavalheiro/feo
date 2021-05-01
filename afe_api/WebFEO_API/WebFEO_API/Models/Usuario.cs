using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebFEO_API.Models
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
        
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        internal AppDb Db { get; set; }

        public Usuario()
        {
        }

        internal Usuario(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `t_usuario` (`usuario`, `senha`,`tipo`, `nome`) VALUES (@usuario, @senha, @tipo, @nome);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `t_usuario` SET `usuario` = @usuario, `senha` = @senha, `tipo` = @tipo, `nome` = @nome WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_usuario` WHERE `Id` = @id;";
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
                ParameterName = "@usuario",
                DbType = DbType.String,
                Value = Login,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@senha",
                DbType = DbType.String,
                Value = Senha,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@tipo",
                DbType = DbType.String,
                Value = Tipo,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@nome",
                DbType = DbType.String,
                Value = Nome,
            });
        }



    }
}
