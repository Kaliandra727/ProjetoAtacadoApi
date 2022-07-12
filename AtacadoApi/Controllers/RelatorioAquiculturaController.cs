using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioAquiculturaController : ControllerBase
    {
        private RelatorioAquiculturaService servico;

        public RelatorioAquiculturaController(AtacadoContext contexto)
        {
            this.servico = new RelatorioAquiculturaService(contexto);
        }

        [HttpGet("{idAquicultura:int}/{ano:int}/{idMunicipio:int}")]
        public ActionResult<List<RelatorioAquiculturaPoco>> GetByIdAquiculturaAnoIdMunicipio(int idAquicultura, int ano, int idMunicipio)
        {
            try
            {
                List<RelatorioAquiculturaPoco> retorno = this.servico.PesquisaPorIdAquiculturaAnoIdmunicipio(idAquicultura, ano, idMunicipio);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{idMunicipio:int}/{ano:int}")]
        public ActionResult<List<RelatorioAquiculturaPoco>> GetByIMunicipioAnoProducao(int idMunicipio, int ano)
        {
            try
            {
                List<RelatorioAquiculturaPoco> retorno = this.servico.PesquisaPorIdMunicipioAnoProducao(idMunicipio, ano);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
