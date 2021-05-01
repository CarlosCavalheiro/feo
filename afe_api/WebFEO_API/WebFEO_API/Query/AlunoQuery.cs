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
    public class AlunoQuery
    {
        public AppDb Db { get; }

        public AlunoQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Aluno> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `nome_completo`, `foto` , `modalidade` , `cep` , `endereco` , `numero` , `bairro` , `cidade` , `estado` , `telefone1` , `telefone2` , `t_responsavel_id` , `t_docente_id` , `t_usuario_id` FROM `t_aluno` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Aluno>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `nome_completo`, `foto` , `modalidade` , `cep` , `endereco` , `numero` , `bairro` , `cidade` , `estado` , `telefone1` , `telefone2` , `t_responsavel_id` , `t_docente_id` , `t_usuario_id`  FROM `t_aluno` ORDER BY `id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_aluno`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Aluno>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Aluno>();
                using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Aluno(Db)
                    {
                        Id = reader.GetInt32(0),
                        NomeCompleto = reader.GetString(1),
                        Foto = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Modalidade = reader.IsDBNull(3)? null : reader.GetString(3),
                        CEP = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Endereco = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Numero = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Bairro = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Cidade = reader.IsDBNull(8) ? null : reader.GetString(8),
                        Estado = reader.IsDBNull(9) ? null : reader.GetString(9),
                        Telefone1 = reader.IsDBNull(10) ? null : reader.GetString(10),
                        Telefone2 = reader.IsDBNull(11) ? null : reader.GetString(11),
                        ResponsavelId = reader.GetInt32(12),
                        DocenteId = reader.GetInt32(13),
                        UsuarioId = reader.GetInt32(14),

                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
