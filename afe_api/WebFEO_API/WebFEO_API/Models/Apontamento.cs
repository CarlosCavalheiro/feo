using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebFEO_API.Models
{
    public class Apontamento
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonProperty("dataApontamento")]
        public DateTime DataApontamento { get; set; }

        [JsonProperty("hora")]
        public string Hora { get; set; }

        [JsonProperty("observacao")]
        public string Observacao { get; set; }

        [JsonProperty("posicaoGPS")]
        public string PosicaoGPS { get; set; }

        [JsonProperty("dispositivo")]
        public string Dispositivo { get; set; }

        [JsonProperty("usuarioId")]
        public long UsuarioId { get; set; }

        [JsonProperty("tipoApontamentoId")]
        public long TipoApontamentoId { get; set; }



        internal AppDb Db { get; set; }

        public Apontamento()
        {
        }

        internal Apontamento(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `t_apontamento` (`data_apontamento`,`hora`, `observacao`,`posicao_gps`,`dispositivo`,`t_usuario_id`,`t_tipo_apontamento_id`) VALUES (@data_apontamento, @hora, @observacao, @posicao_gps, @dispositivo, @t_usuario_id, @t_tipo_apontamento_id);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `t_apontamento` SET `data_apontamento` = @data_apontamento, `hora` = @hora, `observacao` = @observacao, `posicao_gps` = @posicao_gps, `dispositivo` = @dispositivo, `t_usuario_id` = @t_usuario_id, `t_tipo_apontamento_id` = @t_tipo_apontamento WHERE `Id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_apontamento` WHERE `Id` = @id;";
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
                ParameterName = "@data",
                DbType = DbType.DateTime,
                Value = Data,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@data_apontamento",
                DbType = DbType.Date,
                Value = DataApontamento,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@hora",
                DbType = DbType.Time,
                Value = Hora,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@observacao",
                DbType = DbType.String,
                Value = Observacao,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@posicao_gps",
                DbType = DbType.String,
                Value = PosicaoGPS,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@dispositivo",
                DbType = DbType.String,
                Value = Dispositivo,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@t_usuario_id",
                DbType = DbType.Int32,
                Value = UsuarioId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@t_tipo_apontamento_id",
                DbType = DbType.Int32,
                Value = TipoApontamentoId,
            });

        }



    }
}
