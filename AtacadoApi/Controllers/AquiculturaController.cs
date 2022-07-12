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
    public class AquiculturaController : ControllerBase
    {
        private AquiculturaService servico;

        public AquiculturaController(AtacadoContext contexto) : base()
        {
            this.servico = new AquiculturaService(contexto);
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a Quantidade (take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Conjunto de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<AquiculturaEnvelopeJSON>> Get(int skip, int take)
        {
            try
            {
                List<AquiculturaEnvelopeJSON> lista = this.servico.Listar(skip, take);
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
        public ActionResult<AquiculturaEnvelopeJSON> GetByID(int id)
        {
            try
            {
                AquiculturaEnvelopeJSON achado = this.servico.Selecionar(id);
                return achado;
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Cria um novo registro de Aquicultura.
        /// </summary>
        /// <param name="poco">Dados que a serem inseridos.</param>
        /// <returns>O novo registro e seus dados.</returns>

        [HttpPost]
        public ActionResult<AquiculturaEnvelopeJSON> Post([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON criado = this.servico.Criar(poco);
                return Ok(criado);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Atualiza os dados de um registro de Aquicultura.
        /// </summary>
        /// <param name="poco">Dados a serem atualizados.</param>
        /// <returns>Dados atualizados.</returns>

        [HttpPut]
        public ActionResult<AquiculturaEnvelopeJSON> Put([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON atualizado = this.servico.Atualizar(poco);
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Excluiu os registros de Aquicultura.
        /// </summary>
        /// <param name="poco">Registros a serem excluidos.</param>
        /// <returns>Coleção de dados deletados.</returns>

        [HttpDelete]
        public ActionResult<AquiculturaEnvelopeJSON> Delete([FromBody] AquiculturaPoco poco)
        {
            try
            {
                AquiculturaEnvelopeJSON excluido = this.servico.Excluir(poco);
                return Ok(excluido);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui um registro de Aquicultura.
        /// </summary>
        /// <param name="id">Registro a ser excluido.</param>
        /// <returns>rRegistro que foi excluido.</returns>

        [HttpDelete("{id:int}")]
        public ActionResult<AquiculturaEnvelopeJSON> DeleteById(int id)
        {
            try
            {
                AquiculturaEnvelopeJSON excluido = this.servico.Excluir(id);
                return Ok(excluido);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
