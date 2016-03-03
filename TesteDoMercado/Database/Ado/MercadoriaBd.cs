using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TesteDoMercado.Enum;

namespace TesteDoMercado.Database.Ado
{
    public class MercadoriaBd
    {
        private Conexao _conexaoDb;

        public MercadoriaBd()
        {
            _conexaoDb = new Conexao();
        }

        public List<Models.Mercadoria> ListarMercadorias()
        {
           var conexao = _conexaoDb.Abrir();

           var comando = new SqlCommand
           {
               Connection = (SqlConnection)conexao,
               CommandType = System.Data.CommandType.Text,
               CommandText = "SELECT * FROM Mercadorias",
           };


           var dr = comando.ExecuteReader();
           var lista = new List<Models.Mercadoria>();

           while (dr.Read())
           {
               var mercadoria = new Models.Mercadoria
               {
                   Id = Convert.ToInt32(dr["Id"]),
                   Codigo = dr["CodigoMercadoria"].ToString(),
                   Nome = dr["NomeMercadoria"].ToString(),
                   Preco = Convert.ToDecimal(dr["Preco"]),
                   Quantidade = Convert.ToInt32(dr["Quantidade"]),
                   Tipo = dr["TipoMercadoria"].ToString(),
                   TipoNegocio = (TipoNegocio)dr["TipoDescricao"]

               };


               lista.Add(mercadoria);
           }

            _conexaoDb.Fechar();

            return lista;
        }

        public Models.Mercadoria ListarPorId(int id)
        {
            return ListarMercadorias().FirstOrDefault(x => x.Id == id);
        }

        public void AdicionarMercadoria(Models.Mercadoria mercadoria)
        {
            var conexao = _conexaoDb.Abrir();

            var comando = new SqlCommand 
            {
                Connection = (SqlConnection)conexao,
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO Mercadorias(CodigoMercadoria, TipoMercadoria, NomeMercadoria, Quantidade, Preco, TipoDescricao) VALUES (@CodigoMercadoria, @TipoMercadoria, @NomeMercadoria, @Quantidade, @Preco, @TipoDescricao)"
            };

            // passar os valores de parametro aqui
            comando.Parameters.Add(new SqlParameter("@CodigoMercadoria", mercadoria.Codigo));
            comando.Parameters.Add(new SqlParameter("@TipoMercadoria", mercadoria.Tipo));
            comando.Parameters.Add(new SqlParameter("@NomeMercadoria", mercadoria.Nome));
            comando.Parameters.Add(new SqlParameter("@Quantidade", mercadoria.Quantidade));
            comando.Parameters.Add(new SqlParameter("@Preco", mercadoria.Preco));
            comando.Parameters.Add(new SqlParameter("@TipoDescricao", mercadoria.TipoNegocio));
            
            comando.ExecuteNonQuery();
            _conexaoDb.Fechar();
        }

        public void AlterarMercadoria(Models.Mercadoria mercadoria)
        {
            var conexao = _conexaoDb.Abrir();

            var comando = new SqlCommand
            {
                Connection = (SqlConnection)conexao,
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE Mercadorias SET CodigoMercadoria = @CodigoMercadoria, TipoMercadoria = @TipoMercadoria , NomeMercadoria = @NomeMercadoria, Quantidade = @Quantidade, Preco = @Preco, TipoDescricao = @TipoDescricao WHERE Id = @Id",
            };

            // passar os valores de parametro aqui
            comando.Parameters.Add(new SqlParameter("@Id", mercadoria.Id));
            comando.Parameters.Add(new SqlParameter("@CodigoMercadoria", mercadoria.Codigo));
            comando.Parameters.Add(new SqlParameter("@TipoMercadoria", mercadoria.Tipo));
            comando.Parameters.Add(new SqlParameter("@NomeMercadoria", mercadoria.Nome));
            comando.Parameters.Add(new SqlParameter("@Quantidade", mercadoria.Quantidade));
            comando.Parameters.Add(new SqlParameter("@Preco", mercadoria.Preco));
            comando.Parameters.Add(new SqlParameter("@TipoDescricao", mercadoria.TipoNegocio));

            comando.ExecuteNonQuery();
            _conexaoDb.Fechar();
        }
    }
}