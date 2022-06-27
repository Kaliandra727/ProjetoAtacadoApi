using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
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
    public class TipoRebanhoService : BaseAncestralService<TipoRebanhoPoco, TipoRebanho>
    {
        private TipoRebanhoMapper mapConfig;
        private TipoRebanhoRepository repositorio;

        public TipoRebanhoService()
        {
            this.mapConfig = new TipoRebanhoMapper();
            this.repositorio = new TipoRebanhoRepository(new AtacadoContext());
        }

        public override List<TipoRebanhoPoco> Listar()
        {
            List<TipoRebanho> listDom = this.repositorio.Read().ToList();
            return this.ProcessarListaDOM(listDom);
        }

        public override TipoRebanhoPoco Selecionar(int id)
        {
            TipoRebanho dom = this.repositorio.Read(id);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(dom);
            return poco;
        }

        public override TipoRebanhoPoco Criar(TipoRebanhoPoco obj)
        {
            TipoRebanho dom = this.mapConfig.Mapper.Map<TipoRebanho>(obj);
            TipoRebanho criado = this.repositorio.Add(dom);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(criado);
            return poco;
        }

        public List<TipoRebanhoPoco> Listar(int pular, int exibir)
        {
            List<TipoRebanho> listDom = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDom);
        }

        protected override List<TipoRebanhoPoco> ProcessarListaDOM(List<TipoRebanho> listDOM)
        {
            return listDOM.Select(dom => this.mapConfig.Mapper.Map<TipoRebanhoPoco>(dom)).ToList();
        }

        public override TipoRebanhoPoco Atualizar(TipoRebanhoPoco obj)
        {
            TipoRebanho dom = this.mapConfig.Mapper.Map<TipoRebanho>(obj);
            TipoRebanho atualizado = this.repositorio.Edit(dom);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(atualizado);
            return poco;
        }

        public override TipoRebanhoPoco Excluir(TipoRebanhoPoco obj)
        {
            return this.Excluir(obj.IdTipo);
        }

        public override TipoRebanhoPoco Excluir(int id)
        {
            TipoRebanho excluido = this.repositorio.DeleteById(id);
            TipoRebanhoPoco poco = this.mapConfig.Mapper.Map<TipoRebanhoPoco>(excluido);
            return poco;
        }
    }
}
