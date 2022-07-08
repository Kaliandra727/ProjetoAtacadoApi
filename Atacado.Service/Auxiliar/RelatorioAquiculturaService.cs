using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Repository.IBGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class RelatorioAquiculturaService
    {
        private AtacadoContext contexto;
        private AquiculturaRepository aquiculturaRepo;
        private TipoAquiculturaRepository tipoAquiculturarepo;
        private MunicipioRepository municipioRepo;
        private UnidadesFederacaoRepository ufRepo;

        public RelatorioAquiculturaService()
        {
            this.contexto = new AtacadoContext();
            this.aquiculturaRepo = new AquiculturaRepository(new AtacadoContext());
            this.tipoAquiculturarepo = new TipoAquiculturaRepository(new AtacadoContext());
            this.municipioRepo = new MunicipioRepository(new AtacadoContext());
            this.ufRepo = new UnidadesFederacaoRepository(new AtacadoContext());
        }

        public List<RelatorioAquiculturaPoco> PesquisaPorIdAquiculturaAnoIdmunicipio(int idAquicultura, int ano, int idMunicipio)
        {
            List<RelatorioAquiculturaPoco> retorno =
                (from aqi in this.contexto.Aquiculturas
                 join tip in this.contexto.TipoAquiculturas on aqi.IdTipoAquicultura equals tip.IdTipoAquicultura
                 join mun in this.contexto.Municipio1s on aqi.IdMunicipio equals mun.CodIbge7
                 join uf in this.contexto.UnidadesFederacaos on mun.SiglaUf equals uf.SiglaUf
                 where (aqi.IdAquicultura == idAquicultura) && (aqi.Ano == ano) && (aqi.IdMunicipio == idMunicipio)
                 select new RelatorioAquiculturaPoco
                 {
                     IdAquicultura = aqi.IdAquicultura,
                     IdTipoAquicultura = tip.IdTipoAquicultura,
                     DescricaoTipoAquicultura = tip.Descricao,
                     IdMunicipio = aqi.IdMunicipio,
                     Ano = aqi.Ano,
                     Producao = aqi.Producao,
                     ValorProducao = aqi.ValorProducao,
                     ProporcaoValorProporcao = aqi.ProporcaoValorProducao,
                     Moeda = aqi.Moeda,
                     NomeMunicipio = mun.NomeMunicipio,
                     SiglaUf = uf.SiglaUf,
                     DescricaoUnidadeFederacao = uf.DescricaoUnidadesFederacao,
                 }).ToList();
            return retorno;
        }

        public List<RelatorioAquiculturaPoco> PesquisaPorIdMunicipioAnoProducao(int idMunicipio, int ano)
        { 
            List<RelatorioAquiculturaPoco> retorno = 
                (from aqi in this.contexto.Aquiculturas
                 join tip in this.contexto.TipoAquiculturas on aqi.IdTipoAquicultura equals tip.IdTipoAquicultura
                 join mun in this.contexto.Municipio1s on aqi.IdMunicipio equals mun.CodIbge7
                 join uf in this.contexto.UnidadesFederacaos on mun.SiglaUf equals uf.SiglaUf
                 where (aqi.IdMunicipio == idMunicipio) && (aqi.Ano == ano) && (aqi.Producao != null)
                 select new RelatorioAquiculturaPoco
                 {
                     IdAquicultura = aqi.IdAquicultura,
                     IdTipoAquicultura = tip.IdTipoAquicultura,
                     DescricaoTipoAquicultura = tip.Descricao,
                     IdMunicipio = aqi.IdMunicipio,
                     Ano = aqi.Ano,
                     Producao = aqi.Producao,
                     ValorProducao = aqi.ValorProducao,
                     ProporcaoValorProporcao = aqi.ProporcaoValorProducao,
                     Moeda = aqi.Moeda,
                     NomeMunicipio = mun.NomeMunicipio,
                     SiglaUf = uf.SiglaUf,
                     DescricaoUnidadeFederacao = uf.DescricaoUnidadesFederacao,
                 }).ToList();
            return retorno;
        }
    }
}
