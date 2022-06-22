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
    public class AreaConhecimentoService : BaseAncestralService<AreaConhecimentoPoco>
    {
        private AreaConhecimentoMapper mapConfig;
        private AreaConhecimentoDao dao;

        public AreaConhecimentoService()
        {
            this.mapConfig = new AreaConhecimentoMapper();
            this.dao = new AreaConhecimentoDao();
        }

        public override List<AreaConhecimentoPoco> Listar()
        {
            List<AreaConhecimento> listDom = this.dao.ReadAll().Skip(0).Take(100).ToList();
            List<AreaConhecimentoPoco> listPoco = new List<AreaConhecimentoPoco>();
            foreach (AreaConhecimento item in listDom)
            {
                AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override AreaConhecimentoPoco Selecionar(int id)
        {
            AreaConhecimento dom = this.dao.Read(id);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(dom);
            return poco;
        }

        public override AreaConhecimentoPoco Criar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapConfig.Mapper.Map<AreaConhecimento>(obj);
            AreaConhecimento criado = this.dao.Create(dom);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(criado);
            return poco;
        }

        public List<AreaConhecimentoPoco> Listar(int pular, int exibir)
        {
            List<AreaConhecimento> listDom = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDom);
        }

        private List<AreaConhecimentoPoco> ProcessarListaDOM(List<AreaConhecimento> listDom)
        {
            List<AreaConhecimentoPoco> listPoco = new List<AreaConhecimentoPoco>();
            foreach (AreaConhecimento item in listDom)
            {
                AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(item);
                listPoco.Add(poco);
            }
            return listPoco;
        }

        public override AreaConhecimentoPoco Atualizar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapConfig.Mapper.Map<AreaConhecimento>(obj);
            AreaConhecimento atualizado = this.dao.Update(dom);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(atualizado);
            return poco;
        }

        public override AreaConhecimentoPoco Excluir(AreaConhecimentoPoco obj)
        {
            return this.Excluir(obj.IdAreaConhecimento);
        }

        public override AreaConhecimentoPoco Excluir(int id)
        {
            AreaConhecimento excluido = this.dao.Delete(id);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(excluido);
            return poco;
        }
    }
}
