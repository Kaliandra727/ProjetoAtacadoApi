using Atacado.Dal.Estoque;
using Atacado.EF.Database;
using Atacado.Mapper.Estoque;
using Atacado.Poco.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class ProdutoService : BaseAncestralService<ProdutoPoco>
    {
        private ProdutoMapper mapConfig;
        private ProdutoDao dao;

        public ProdutoService()
        {
            this.mapConfig = new ProdutoMapper();
            this.dao = new ProdutoDao();
        }

        public override List<ProdutoPoco> Listar()
        {
            List<Produto> listDom = this.dao.ReadAll().Skip(0).Take(100).ToList();
            List<ProdutoPoco> listPoco = new List<ProdutoPoco>();
            foreach (Produto item in listDom)
            {
                ProdutoPoco poco = this.mapConfig.Mapper.Map<ProdutoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override ProdutoPoco Selecionar(int id)
        {
            Produto dom = this.dao.Read(id);
            ProdutoPoco poco = this.mapConfig.Mapper.Map<ProdutoPoco>(dom);
            return poco;
        }

        public override ProdutoPoco Criar(ProdutoPoco obj)
        {
            Produto dom = this.mapConfig.Mapper.Map<Produto>(obj);
            Produto criado = this.dao.Create(dom);
            ProdutoPoco poco = this.mapConfig.Mapper.Map<ProdutoPoco>(criado);
            return poco;
        }

        public List<ProdutoPoco> Listar(int pular, int exibir)
        {
            List<Produto> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<ProdutoPoco> ProcessarListaDOM(List<Produto> listDom)
        {
            List<ProdutoPoco> listPoco = new List<ProdutoPoco>();
            foreach (Produto item in listDom)
            {
                ProdutoPoco poco = this.mapConfig.Mapper.Map<ProdutoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override ProdutoPoco Atualizar(ProdutoPoco obj)
        {
            Produto dom = this.mapConfig.Mapper.Map<Produto>(obj);
            Produto atualizado = this.dao.Update(dom);
            ProdutoPoco poco = this.mapConfig.Mapper.Map<ProdutoPoco>(atualizado);
            return poco;
        }

        public override ProdutoPoco Excluir(ProdutoPoco obj)
        {
            return this.Excluir(obj.IdProduto);
        }

        public override ProdutoPoco Excluir(int id)
        {
            Produto excluido = this.dao.Delete(id);
            ProdutoPoco poco = this.mapConfig.Mapper.Map<ProdutoPoco>(excluido);
            return poco;
        }
    }
}