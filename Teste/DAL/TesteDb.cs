using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Teste.DML;

namespace Teste.DAL
{
    public class TesteDb
    {
        public SqlConnection Conexao { get; private set; }
        public TesteDb(SqlConnection cn)
        {
            Conexao = cn;
        }

        public Produto ConsultarProduto(int id)
        {
            Produto produto = new Produto();

            using (SqlCommand cmd = Conexao.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (Conexao.State != System.Data.ConnectionState.Open)
                    Conexao.Open();

                cmd.CommandText = "PR_Consulta_Produto";
                SqlParameter produtoId = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                produtoId.SqlValue = id;
                produtoId.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(produtoId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        produto.ProdutoId = dr.GetInt32(0);
                        produto.Nome = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                        produto.Descricao = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                        produto.Preco = dr.GetDecimal(3);
                        produto.Categria = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                    }
                }
            }

            return produto;
        }

        public void AlterarProduto(Produto entidade)
        {
            using (SqlCommand cmd = Conexao.CreateCommand())
            {
                if (Conexao.State != System.Data.ConnectionState.Open)
                    Conexao.Open();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Alterar_Produto";

                SqlParameter produtoId = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                produtoId.SqlValue = entidade.ProdutoId;
                produtoId.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(produtoId);

                SqlParameter nome = new SqlParameter("@NOME", System.Data.SqlDbType.VarChar);
                nome.SqlValue = entidade.Nome;
                nome.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(nome);

                SqlParameter descricao = new SqlParameter("@descricao", System.Data.SqlDbType.VarChar);
                descricao.SqlValue = entidade.Descricao;
                descricao.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(descricao);

                SqlParameter preco = new SqlParameter("@preco", System.Data.SqlDbType.Decimal);
                preco.SqlValue = entidade.Preco;
                preco.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(preco);

                SqlParameter categoria = new SqlParameter("@categoria", System.Data.SqlDbType.VarChar);
                categoria.SqlValue = entidade.Categria;
                categoria.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(categoria);

                cmd.ExecuteNonQuery();
            }
        }

        public int IncluirProduto(Produto entidade)
        {
            using (SqlCommand cmd = Conexao.CreateCommand())
            {
                if (Conexao.State != System.Data.ConnectionState.Open)
                    Conexao.Open();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Incluir_Produto";

                SqlParameter nome = new SqlParameter("@nome", System.Data.SqlDbType.VarChar);
                nome.SqlValue = entidade.Nome;
                nome.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(nome);

                SqlParameter descricao = new SqlParameter("@descricao", System.Data.SqlDbType.VarChar);
                descricao.SqlValue = entidade.Descricao;
                descricao.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(descricao);

                SqlParameter preco = new SqlParameter("@preco", System.Data.SqlDbType.Decimal);
                preco.SqlValue = entidade.Preco;
                preco.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(preco);

                SqlParameter categoria = new SqlParameter("@categoria", System.Data.SqlDbType.VarChar);
                categoria.SqlValue = entidade.Categria;
                categoria.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(categoria);

                SqlParameter produtoId = new SqlParameter("@id", System.Data.SqlDbType.Int);
                produtoId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(produtoId);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.Parameters["@id"].Value);
            }
        }

        public void ExcluirProduto(int Id)
        {
            using (SqlCommand cmd = Conexao.CreateCommand())
            {
                if (Conexao.State != System.Data.ConnectionState.Open)
                    Conexao.Open();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PR_Excluir_Produto";

                SqlParameter produtoId = new SqlParameter("@id", System.Data.SqlDbType.Int);
                produtoId.SqlValue = Id;
                produtoId.Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.Add(produtoId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}