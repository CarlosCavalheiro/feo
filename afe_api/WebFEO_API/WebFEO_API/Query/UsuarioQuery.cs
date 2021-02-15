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
    public class UsuarioQuery
    {
        public AppDb Db { get; }

        public UsuarioQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Usuario> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `usuario`, `senha`, `tipo` FROM `t_usuario` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Usuario>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `usuario`, `senha`, `tipo` FROM `t_usuario` ORDER BY `id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_usuario`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Usuario>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Usuario>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Usuario(Db)
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Senha = reader.GetString(2),
                        Tipo = reader.GetString(3),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
