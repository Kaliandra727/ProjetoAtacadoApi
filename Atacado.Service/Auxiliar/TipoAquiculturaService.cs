using Atacado.EF.Database;
using Atacado.Envelope.Auxiliar;
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
    public class TipoAquiculturaService : BaseEnvelopadaService<TipoAquiculturaPoco, TipoAquicultura, TipoAquiculturaEnvelopeJSON>
    {
        private TipoAquiculturaRepository repositorio;

        public TipoAquiculturaService() : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<TipoAquiculturaPoco, TipoAquicultura, TipoAquiculturaEnvelopeJSON>();
            this.repositorio = new TipoAquiculturaRepository(new AtacadoContext());
        }

        public TipoAquiculturaService(AtacadoContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<TipoAquiculturaPoco, TipoAquicultura, TipoAquiculturaEnvelopeJSON>();
            this.repositorio = new TipoAquiculturaRepository(contexto);
        }

        public List<TipoAquiculturaEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<TipoAquicultura> listDom = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listDom);
        }

        protected override List<TipoAquiculturaEnvelopeJSON> ProcessarListaDOM(List<TipoAquicultura> listDOM)
        {
            List<TipoAquiculturaEnvelopeJSON> lista = listDOM.Select(dom => this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override TipoAquiculturaEnvelopeJSON Atualizar(TipoAquiculturaPoco obj)
        {
            TipoAquicultura tipo = this.mapeador.Mecanismo.Map<TipoAquicultura>(obj);
            TipoAquicultura atualizado = this.repositorio.Edit(tipo);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(atualizado);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Criar(TipoAquiculturaPoco obj)
        {
            TipoAquicultura tipo = this.mapeador.Mecanismo.Map<TipoAquicultura>(obj);
            TipoAquicultura criado = this.repositorio.Add(tipo);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Excluir(TipoAquiculturaPoco obj)
        {
            TipoAquicultura tipo = this.mapeador.Mecanismo.Map<TipoAquicultura>(obj);
            TipoAquicultura excluido = this.repositorio.Delete(tipo);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Excluir(int id)
        {
            TipoAquicultura excluido = this.repositorio.DeleteById(id);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override TipoAquiculturaEnvelopeJSON Selecionar(int id)
        {
            TipoAquicultura achado = this.repositorio.Read(id);
            TipoAquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TipoAquiculturaEnvelopeJSON>(achado);
            json.SetLinks();
            return json;
        }
    }
}
