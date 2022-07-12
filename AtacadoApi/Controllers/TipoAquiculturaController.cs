using Atacado.EF.Database;
using Atacado.Envelope.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAquiculturaController : ControllerBase
    {
        private TipoAquiculturaService servico;

        public TipoAquiculturaController(AtacadoContext contexto) : base()
        {
            this.servico = new TipoAquiculturaService(contexto);
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a Quantidade (take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Conjunto de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<TipoAquiculturaEnvelopeJSON>> Get(int skip, int take)
        {
            try
            {
                List<TipoAquiculturaEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Realiza busca pelos registros através do ID.
        /// </summary>
        /// <param name="id">Código pelo qual a busca deverá ser realizada.</param>
        /// <returns>Informações Ligadas ao código inserido.</returns>

        [HttpGet("{id:int}")]
        public ActionResult<TipoAquiculturaEnvelopeJSON> GetByID(int id)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON achado = this.servico.Selecionar(id);
                return achado;
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Cria um novo Tipo de Aquicultura.
        /// </summary>
        /// <param name="poco">Dados que a serem inseridos.</param>
        /// <returns>O novo Tipo de Aquicultura e seus dados.</returns>

        [HttpPost]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Post([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON criado = this.servico.Criar(poco);
                return Ok(criado);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Atualiza os dados de um Tipo de Aquicultura.
        /// </summary>
        /// <param name="poco">Dados a serem atualizados.</param>
        /// <returns>Dados atualizados.</returns>

        [HttpPut]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Put([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON atualizado = this.servico.Atualizar(poco);
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Excluiu os registros de TipoAquicultura.
        /// </summary>
        /// <param name="poco">Registros a serem excluidos.</param>
        /// <returns>Coleção de dados deletados.</returns>

        [HttpDelete]
        public ActionResult<TipoAquiculturaEnvelopeJSON> Delete([FromBody] TipoAquiculturaPoco poco)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON excluido = this.servico.Excluir(poco);
                return Ok(excluido);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui um registro de TipoAquicultura.
        /// </summary>
        /// <param name="id">Registro a ser excluido.</param>
        /// <returns>rRegistro que foi excluido.</returns>

        [HttpDelete("{id:int}")]
        public ActionResult<TipoAquiculturaEnvelopeJSON> DeleteById(int id)
        {
            try
            {
                TipoAquiculturaEnvelopeJSON excluido = this.servico.Excluir(id);
                return Ok(excluido);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
