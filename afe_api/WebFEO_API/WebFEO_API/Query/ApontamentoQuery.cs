using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebFEO_API.Models;

namespace WebFEO_API.Query
{
    public class ApontamentoQuery
    {
        public AppDb Db { get; }

        public ApontamentoQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Apontamento> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `data`,`data_apontamento`,`hora`, `observacao`,`posicao_gps`,`dispositivo`,`t_usuario_id`,`t_tipo_apontamento_id` FROM `t_apontamento` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Apontamento>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `data`, `data_apontamento`, `hora`, `observacao`,`posicao_gps`,`dispositivo`,`t_usuario_id`,`t_tipo_apontamento_id` FROM `t_apontamento` ORDER BY `id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_apontamento`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Apontamento>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Apontamento>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Apontamento(Db)
                    {
                        Id = reader.GetInt32(0),
                        Data = reader.GetDateTime(1),
                        DataApontamento = reader.GetDateTime(2),
                        Hora = Convert.ToDateTime(reader[3].ToString()).ToString("HH:mm:ss"),
                        Observacao = reader.IsDBNull(4) ? null : reader.GetString(4),
                        PosicaoGPS = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Dispositivo = reader.IsDBNull(6) ? null : reader.GetString(6),
                        UsuarioId = reader.GetInt32(7),
                        TipoApontamentoId = reader.GetInt32(8),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
