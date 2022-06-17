using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Teste
{
    public class SubcategoriaTeste
    {
        public void Executar()
        {
            SubcategoriaService srv = new SubcategoriaService();
            List<SubcategoriaPoco> listaPoco = srv.Listar();
            foreach (SubcategoriaPoco poco in listaPoco)
            {
                Console.WriteLine("ID: {0}", poco.IdSubcategoria);
                Console.WriteLine("ID Categoria: {0}", poco.IdCategoria);
                Console.WriteLine("Descriçãoo: {0}", poco.DescricaoSubcategoria);
                Console.WriteLine("Situação: {0}", poco.Situacao);
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
