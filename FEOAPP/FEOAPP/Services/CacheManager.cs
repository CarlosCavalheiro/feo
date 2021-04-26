using System;
using System.Collections.Generic;
using System.Text;

namespace FEOAPP.Services
{
    public abstract class CacheManager<T>
    {
        protected DataBase db;

        public CacheManager(ref DataBase conn)
        {
            //Obter Conexao
            this.db = conn;

            //Verifica se tabela existe, caso não cria!
            conn.Conexao().CreateTable<T>();
        }

        public virtual void Insert(ref T obj) { db.Conexao().Insert(obj); }

        public virtual int Update(ref T obj) { return db.Conexao().Update(obj); }

        public virtual int Delete(ref T obj) { return db.Conexao().Delete(obj); }

        public virtual int DeleteAll() { throw new NotImplementedException(); }

        public virtual void InsertAll(ref List<T> objs) { throw new NotImplementedException(); }

        public virtual List<T> SelectAll() { throw new NotImplementedException(); }

    }
}
