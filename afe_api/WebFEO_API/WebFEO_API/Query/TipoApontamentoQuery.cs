using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebFEO_API.Models;

namespace WebFEO_API.Query
{
    public class TipoApontamentoQuery
    {
        public AppDb Db { get; }

        public TipoApontamentoQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<TipoApontamento> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `descricao` FROM `t_tipo_apontamento` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<TipoApontamento>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `descricao` FROM `t_tipo_apontamento` ORDER BY `id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_tipo_apontamento`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<TipoApontamento>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<TipoApontamento>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new TipoApontamento(Db)
                    {
                        Id = reader.GetInt32(0),
                        Descricao = reader.IsDBNull(1) ? null : reader.GetString(1),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
