using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteDoMercado.Database.Ado
{
    public class Conexao
    {
        private SqlConnection _connection;

        public Conexao()
        {
            string strConn = ConfigurationManager.ConnectionStrings["AWSSql"].ConnectionString;
            _connection = new SqlConnection(strConn);
        }

        public virtual DbConnection Abrir()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fechar()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Dispose(); // limpar o objeto Connection da memória
        }

    }
}