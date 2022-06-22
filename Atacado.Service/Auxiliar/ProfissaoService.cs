using Atacado.Dal.Auxiliar;
using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class ProfissaoService : BaseAncestralService<ProfissaoPoco>
    {
        private ProfissaoMapper mapConfig;
        private ProfissaoDao dao;

        public ProfissaoService()
        {
            this.mapConfig = new ProfissaoMapper();
            this.dao = new ProfissaoDao();
        }

        public override List<ProfissaoPoco> Listar()
        {
            List<Profissao> listDom = this.dao.ReadAll().Skip(0).Take(100).ToList();
            List<ProfissaoPoco> listPoco = new List<ProfissaoPoco>();
            foreach (Profissao item in listDom)
            {
                ProfissaoPoco poco = this.mapConfig.Mapper.Map<ProfissaoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override ProfissaoPoco Selecionar(int id)
        {
            Profissao dom = this.dao.Read(id);
            ProfissaoPoco poco = this.mapConfig.Mapper.Map<ProfissaoPoco>(dom);
            return poco;
        }

        public override ProfissaoPoco Criar(ProfissaoPoco obj)
        {
            Profissao dom = this.mapConfig.Mapper.Map<Profissao>(obj);
            Profissao criado = this.dao.Create(dom);
            ProfissaoPoco poco = this.mapConfig.Mapper.Map<ProfissaoPoco>(criado);
            return poco;
        }

        public List<ProfissaoPoco> Listar(int pular, int exibir)
        {
            List<Profissao> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<ProfissaoPoco> ProcessarListaDOM(List<Profissao> listDom)
        {
            List<ProfissaoPoco> listPoco = new List<ProfissaoPoco>();
            foreach (Profissao item in listDom)
            {
                ProfissaoPoco poco = this.mapConfig.Mapper.Map<ProfissaoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override ProfissaoPoco Atualizar(ProfissaoPoco obj)
        {
            Profissao dom = this.mapConfig.Mapper.Map<Profissao>(obj);
            Profissao atualizado = this.dao.Update(dom);
            ProfissaoPoco poco = this.mapConfig.Mapper.Map<ProfissaoPoco>(atualizado);
            return poco;
        }

        public override ProfissaoPoco Excluir(ProfissaoPoco obj)
        {
            return this.Excluir(obj.IdProfissao);
        }

        public override ProfissaoPoco Excluir(int id)
        {
            Profissao excluido = this.dao.Delete(id);
            ProfissaoPoco poco = this.mapConfig.Mapper.Map<ProfissaoPoco>(excluido);
            return poco;
        }
    }
}
