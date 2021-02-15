using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebFEO_API.Models
{
    public class Aluno
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Foto { get; set; }
        public string Modalidade { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        public long ResponsavelId { get; set; }
        public long DocenteId { get; set; }
        public long UsuarioId { get; set; }


        internal AppDb Db { get; set; }

        public Aluno()
        {
        }

        internal Aluno(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `t_aluno` (`nome_completo`, `foto`,`modalidade`,`cep`,`endereco`,`numero`,`bairro`,`cidade`,`estado`,`telefone1`,`telefone2`,`t_responsavel_id`,`t_docente_id`,`t_usuario_id`) VALUES (@nome_completo, @foto, @modalidade, @cep, @endereco, @numero, @bairro, @cidade, @estado, @telefone1, @telefone2, @t_responsavel_id, @t_docente_id, @t_usuario_id);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `t_aluno` SET `nome_completo` = @nome_completo, `foto` = @foto, `modalidade` = @modalidade , `cep` = @cep , `endereco` = @endereco, `numero` = @numero , `bairro` = @bairro, `cidade` = @cidade, `estado` = @estado,`telefone1` = @telefone1, `telefone2` = @telefone2, `t_responsavel_id` = @t_responsavel_id, `t_docente_id` = @t_docente_id, `t_usuario_id` = @t_usuario_id WHERE `id` = @id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `t_aluno` WHERE `Id` = @id;";
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
                ParameterName = "@modalidade",
                DbType = DbType.String,
                Value = Modalidade,
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
                ParameterName = "@t_responsavel_id",
                DbType = DbType.Int32,
                Value = ResponsavelId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@t_docente_id",
                DbType = DbType.Int32,
                Value = DocenteId,
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
