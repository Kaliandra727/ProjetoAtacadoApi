using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.Teste
{
    public class CategoriaTeste
    {
        public void Executar()
        {
            CategoriaService srv = new CategoriaService();
            List<CategoriaPoco> listaPoco = srv.Listar();
            foreach (CategoriaPoco poco in listaPoco)
            {
                Console.WriteLine("ID: {0}", poco.Codigo);
                Console.WriteLine("Descriçãoo: {0}", poco.Descricao);
                Console.WriteLine("Situação: {0}", poco.Situacao);
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
