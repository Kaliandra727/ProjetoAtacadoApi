using Atacado.Envelope.RH;
using Atacado.Poco.RH;
using Atacado.Service.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/rh/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private EmpresaService servico;

        public EmpresaController() : base()
        {
            this.servico = new EmpresaService();
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a Quantidade (take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<EmpresaEnvelopeJSON>> GetAll(int skip, int take)
        {
            try
            {
                List<EmpresaEnvelopeJSON> lista = this.servico.Listar(skip, take);
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
        public ActionResult<EmpresaEnvelopeJSON> GetByID(int id)
        {
            try
            {
                EmpresaEnvelopeJSON achado = this.servico.Selecionar(id);
                return achado;
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Cria uma nova empresa.
        /// </summary>
        /// <param name="poco">Dados que a serem inseridos.</param>
        /// <returns>A nova empresa e seus dados.</returns>

        [HttpPost]
        public ActionResult<EmpresaEnvelopeJSON> Post([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON criado = this.servico.Criar(poco);
                return Ok(criado);
            }
            catch (Exception ex) 
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma empresa.
        /// </summary>
        /// <param name="poco">Dados a serem atualizados.</param>
        /// <returns>Dados atualizados.</returns>

        [HttpPut]
        public ActionResult<EmpresaEnvelopeJSON> Put([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON atualizado = this.servico.Atualizar(poco);
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Excluiu os registros de empresa.
        /// </summary>
        /// <param name="poco">Registros a serem excluidos.</param>
        /// <returns>Coleção de dados deletados.</returns>

        [HttpDelete]
        public ActionResult<EmpresaEnvelopeJSON> Delete([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON excluido = this.servico.Excluir(poco);
                return Ok(excluido);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Exclui um registro de empresa.
        /// </summary>
        /// <param name="id">Registro a ser excluido.</param>
        /// <returns>rRegistro que foi excluido.</returns>

        [HttpDelete("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> DeleteById(int id)
        {
            try
            {
                EmpresaEnvelopeJSON excluido = this.servico.Excluir(id);
                return Ok(excluido);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
