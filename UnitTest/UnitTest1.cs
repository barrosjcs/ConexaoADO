using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Configuration;
using Teste.DAL;
using Teste.DML;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        static SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["ProdutoDb"].ConnectionString);
        readonly TesteDb db = new TesteDb(Conexao);

        [TestMethod]
        public void Consultar()
        {
            Produto produto = db.ConsultarProduto(1);
            Assert.AreEqual(produto.Nome.Trim(), "Bola de Basquete Jaguar Power Jam");
        }

        [TestMethod]
        public void Alterar()
        {
            Produto produto = new Produto();
            produto.ProdutoId = 47;
            produto.Nome = "Teste2";
            produto.Descricao = "Teste2";
            produto.Categria = "Futebol";
            produto.Preco = 50;

            db.AlterarProduto(produto);
            Produto cons = db.ConsultarProduto(47);

            Assert.AreEqual(cons.Nome.Trim(), "Teste2");
        }

        [TestMethod]
        public void Excluir()
        {
            db.ExcluirProduto(47);
            Produto cons = db.ConsultarProduto(47);

            Assert.IsNull(cons.Nome);
        }

        [TestMethod]
        public void Incluir()
        {
            Produto produto = new Produto();
            produto.Nome = "Teste2";
            produto.Descricao = "Teste2";
            produto.Categria = "Futebol";
            produto.Preco = 50;

            int id = db.IncluirProduto(produto);
            Produto cons = db.ConsultarProduto(id);

            Assert.AreEqual(cons.Nome.Trim(), "Teste2");
        }
    }
}
