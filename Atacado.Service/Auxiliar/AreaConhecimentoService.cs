using Atacado.EF.Database;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class AreaConhecimentoService : BaseAncestralService<AreaConhecimentoPoco, AreaConhecimento>
    {
        private AreaConhecimentoRepository repositorio;

        public AreaConhecimentoService()
        {
            this.mapeador = new MapeadorGenerico< AreaConhecimentoPoco, AreaConhecimento > ();
            this.repositorio = new AreaConhecimentoRepository(new AtacadoContext());
        }

        public override List<AreaConhecimentoPoco> Listar()
        {
            List<AreaConhecimento> listDom = this.repositorio.Read().ToList();
            return this.ProcessarListaDOM(listDom);
        }

        public override AreaConhecimentoPoco Selecionar(int id)
        {
            AreaConhecimento dom = this.repositorio.Read(id);
            AreaConhecimentoPoco poco = this.mapeador.Mecanismo.Map<AreaConhecimentoPoco>(dom);
            return poco;
        }

        public override AreaConhecimentoPoco Criar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapeador.Mecanismo.Map<AreaConhecimento>(obj);
            AreaConhecimento criado = this.repositorio.Add(dom);
            AreaConhecimentoPoco poco = this.mapeador.Mecanismo.Map<AreaConhecimentoPoco>(criado);
            return poco;
        }

        public List<AreaConhecimentoPoco> Listar(int pular, int exibir)
        {
            List<AreaConhecimento> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<AreaConhecimentoPoco> ProcessarListaDOM(List<AreaConhecimento> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<AreaConhecimentoPoco>(dom)).ToList();
        }

        public override AreaConhecimentoPoco Atualizar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapeador.Mecanismo.Map<AreaConhecimento>(obj);
            AreaConhecimento atualizado = this.repositorio.Edit(dom);
            AreaConhecimentoPoco poco = this.mapeador.Mecanismo.Map<AreaConhecimentoPoco>(atualizado);
            return poco;
        }

        public override AreaConhecimentoPoco Excluir(AreaConhecimentoPoco obj)
        {
            return this.Excluir(obj.IdAreaConhecimento);
        }

        public override AreaConhecimentoPoco Excluir(int id)
        {
            AreaConhecimento excluido = this.repositorio.DeleteById(id);
            AreaConhecimentoPoco poco = this.mapeador.Mecanismo.Map<AreaConhecimentoPoco>(excluido);
            return poco;
        }
    }
}
