using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FEOAPP.Services
{
    public class DataBase : IDisposable
    {
        private string dbPath;
        private SQLite.SQLiteConnection conexao;
        
        private static DataBase instance;

        private DataBase()
        {
                        
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BDFEO.db3");
            conexao = new SQLite.SQLiteConnection(dbPath);

        }

        public void BeginTransaction()
        {
            this.Conexao().BeginTransaction();

        }

        public void CommitTransaction()
        {
            this.Conexao().Commit();

        }

        public void RollBackTransaction()
        {
            this.Conexao().Rollback();

        }

        public bool TransactionOpen()
        {
            return this.Conexao().IsInTransaction;
        }

        public SQLite.SQLiteConnection Conexao()
        {
            return this.conexao;
        }

        public static DataBase GetInstance()
        {
            if (instance == null)
            {
                instance = new DataBase();
            }
            return instance;
        }

        public void Dispose()
        {
            if (conexao != null)
                conexao.Close();
            conexao.Dispose();
            instance = null;
        }
    }
}
