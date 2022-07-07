using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class RelatorioService
    {
        private AtacadoContext contexto;
        private CategoriaRepository categoriaRepo;
        private SubcategoriaRepository subcategoriaRepo;
        private ProdutoRepository produtoRepo;

        public RelatorioService()
        {
            this.contexto = new AtacadoContext();
            this.categoriaRepo = new CategoriaRepository(this.contexto);
            this.subcategoriaRepo = new SubcategoriaRepository(this.contexto);
            this.produtoRepo = new ProdutoRepository(this.contexto);
        }


        public List<RelatorioPoco> ListarPorCategoria(int idCategoria)
        {
            List<RelatorioPoco> retorno =
                (from cat in this.contexto.Categorias
                join subs in this.contexto.Subcategorias on cat.IdCategoria equals subs.IdCategoria
                join prod in this.contexto.Produtos on subs.IdCategoria equals prod.IdSubcategoria
                where cat.IdCategoria == idCategoria
                    select new RelatorioPoco()
                    {
                        IdCategoria = cat.IdCategoria,
                        DescricaoCategoria = cat.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        DescricaoSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prod.IdProduto,
                        DescricaoProduto = prod.DescricaoProduto,
                    }).ToList();
                return retorno;
        }

        public List<RelatorioPoco> ListarPorSubcategoria(int IdSubcategoria)
        {
            List<RelatorioPoco> busca =
                (from sub in this.subcategoriaRepo.Read()
                 join cat in this.categoriaRepo.Read() on sub.IdSubcategoria equals cat.IdCategoria
                 join prod in this.produtoRepo.Read() on cat.IdCategoria equals prod.IdProduto
                 where sub.IdSubcategoria == IdSubcategoria
                 select new RelatorioPoco()
                 {
                     IdCategoria = cat.IdCategoria,
                     DescricaoCategoria = cat.DescricaoCategoria,
                     IdSubcategoria = sub.IdSubcategoria,
                     DescricaoSubcategoria = sub.DescricaoSubcategoria,
                     IdProduto = prod.IdProduto,
                     DescricaoProduto = prod.DescricaoProduto,
                 }).ToList();
            return busca;
        }

        public RelatorioPoco ListarPorProduto(int idProduto)
        {
            RelatorioPoco busca =
                (from prod in this.contexto.Produtos
                 join cat in this.contexto.Categorias on prod.IdCategoria equals cat.IdCategoria
                 join sub in this.contexto.Subcategorias on prod.IdCategoria equals sub.IdSubcategoria
                 where prod.IdProduto == idProduto
                 select new RelatorioPoco()
                 {
                     IdCategoria = cat.IdCategoria,
                     DescricaoCategoria = cat.DescricaoCategoria,
                     IdSubcategoria = sub.IdSubcategoria,
                     DescricaoSubcategoria = sub.DescricaoSubcategoria,
                     IdProduto = prod.IdProduto,
                     DescricaoProduto = prod.DescricaoProduto,
                 }).Single();
            return busca;
        }
    }
}
