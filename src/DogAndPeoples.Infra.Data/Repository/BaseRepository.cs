using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeoples.Infra.Data.Repository
{
    public abstract class BaseRepository
    {
        public static System.Data.IDbConnection Connection => new SqlConnection(ConfigurationManager.AppSettings["Conexao"]);

        public virtual int Adicionar(string sql, object parametros)
        {
            return Connection.ExecuteScalar<int>(sql, parametros);
        }

        public virtual void Remover(string sql, object parametros)
        {
            Connection.ExecuteScalar<int>(sql, parametros);
        }

        public virtual IEnumerable<T> Listar<T>(string sql, object parametros) where T : class
        {
            return Connection.Query<T>(sql, parametros);
        }

        public virtual T Obter<T>(string sql, object parametros) where T : class
        {
            return Connection.QueryFirst<T>(sql, parametros);
        }
    }
}
