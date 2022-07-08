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
    public class AquiculturaService : BaseEnvelopadaService<AquiculturaPoco, Aquicultura, AquiculturaEnvelopeJSON>
    {
        private AquiculturaRepository repositorio;

        public AquiculturaService() : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<AquiculturaPoco, Aquicultura, AquiculturaEnvelopeJSON>();
            this.repositorio = new AquiculturaRepository(new AtacadoContext());
        }

        public List<AquiculturaEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Aquicultura> listDom = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listDom);
        }

        protected override List<AquiculturaEnvelopeJSON> ProcessarListaDOM(List<Aquicultura> listDOM)
        {
            List<AquiculturaEnvelopeJSON> lista = listDOM.Select(dom => this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override AquiculturaEnvelopeJSON Atualizar(AquiculturaPoco obj)
        {
            Aquicultura tipo = this.mapeador.Mecanismo.Map<Aquicultura>(obj);
            Aquicultura atualizado = this.repositorio.Edit(tipo);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(atualizado);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Criar(AquiculturaPoco obj)
        {
            Aquicultura tipo = this.mapeador.Mecanismo.Map<Aquicultura>(obj);
            Aquicultura criado = this.repositorio.Add(tipo);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Excluir(AquiculturaPoco obj)
        {
            Aquicultura tipo = this.mapeador.Mecanismo.Map<Aquicultura>(obj);
            Aquicultura excluido = this.repositorio.Delete(tipo);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Excluir(int id)
        {
            Aquicultura excluido = this.repositorio.DeleteById(id);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override AquiculturaEnvelopeJSON Selecionar(int id)
        {
            Aquicultura achado = this.repositorio.Read(id);
            AquiculturaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AquiculturaEnvelopeJSON>(achado);
            json.SetLinks();
            return json;
        }
    }
}
