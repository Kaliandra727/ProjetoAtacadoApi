using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Teste
{
    public class ProdutoTeste
    {
        public void Executar()
        {
            ProdutoService srv = new ProdutoService();
            List<ProdutoPoco> listaPoco = srv.Listar();
            foreach (ProdutoPoco poco in listaPoco)
            {
                Console.WriteLine("ID: {0}", poco.IdProduto);
                Console.WriteLine("ID Subcategoria: {0}", poco.IdSubcategoria);
                Console.WriteLine("ID Categoria: {0}", poco.IdCategoria);
                Console.WriteLine("Descriçãoo: {0}", poco.DescricaoProduto);
                Console.WriteLine("Situação: {0}", poco.Situacao);
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
