using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste.DML
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Categria { get; set; }
    }
}