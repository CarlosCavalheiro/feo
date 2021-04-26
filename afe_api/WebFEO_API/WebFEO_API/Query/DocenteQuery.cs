using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class DocenteQuery
    {
        public AppDb Db { get; }

        public DocenteQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Docente> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `nome_completo`, `foto` , `cep` , `endereco` , `numero` , `bairro` , `cidade` , `estado` , `telefone1` , `telefone2` , `t_usuario_id` FROM `t_docente` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Docente>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `nome_completo`, `foto` , `cep` , `endereco` , `numero` , `bairro` , `cidade` , `estado` , `telefone1` , `telefone2` , `t_usuario_id`  FROM `t_docente` ORDER BY `id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_docente`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Docente>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Docente>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Docente(Db)
                    {
                        Id = reader.GetInt32(0),
                        NomeCompleto = reader.IsDBNull(2) ? null : reader.GetString(1),
                        Foto = reader.IsDBNull(2) ? null : reader.GetString(2),
                        CEP = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Endereco = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Numero = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Bairro = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Cidade = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Estado = reader.IsDBNull(8) ? null : reader.GetString(8),
                        Telefone1 = reader.IsDBNull(9) ? null : reader.GetString(9),
                        Telefone2 = reader.IsDBNull(10) ? null : reader.GetString(10),
                        UsuarioId = reader.GetInt32(11),

                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
