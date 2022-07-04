using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Rebanho.
    /// </summary>
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private RebanhoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public RebanhoController()
        {
            this.servico = new RebanhoService();
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a Quantidade (take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<RebanhoPoco>> Get(int skip, int take)
        {
            try
            {
                List<RebanhoPoco> listResposta = this.servico.Listar(skip, take);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Retorna a busca pelo registro que possui o ID indicado.
        /// </summary>
        /// <param name="id">`Número pelo qual a pesquisa é feita.</param>
        /// <returns>Informações sobre o ID indicado.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<RebanhoPoco> GetPorID(int id)
        {
            try
            {
                RebanhoPoco listResposta = this.servico.Selecionar(id);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Reaiza a busca por todos os registros, filtrando o ano de referência (anoRef) e o ID do município (idMun).
        /// </summary>
        /// <param name="anoRef">Ano pelo qual a pesquisa deve buscar.</param>
        /// <param name="idMun">Código que indica qual munícipio a pesquisa será feita.</param>
        /// <returns>Coleção de dados</returns>
        [HttpGet("anoref/{anoRef:int}/idmun/{idMun:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorAnoRefIdMun(int anoRef, int idMun)
        {
            try
            {
                List<RebanhoPoco> listResposta = this.servico.FiltrarPorAnoRefIdMun(anoRef, idMun);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Criação de um novo rebanho.
        /// </summary>
        /// <param name="poco">Novo rebanho a ser inserido.</param>
        /// <returns>As informações do rebanho criado.</returns>
        [HttpPost]
        public ActionResult<RebanhoPoco> Post([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco listResposta = this.servico.Criar(poco);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Atualiza informações sobre um rebanho.
        /// </summary>
        /// <param name="poco">Rebanho a ser atualizado.</param>
        /// <returns>Novas informações do rebanho atualizado.</returns>
        [HttpPut]
        public ActionResult<RebanhoPoco> Put([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco listResposta = this.servico.Atualizar(poco);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Deletar os registros de Rebanho.
        /// </summary>
        /// <param name="poco">Rebanho a ser deletado.</param>
        /// <returns>O rebanho que foi deletado.</returns>
        [HttpDelete]
        public ActionResult<RebanhoPoco> Delete([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco listResposta = this.servico.Excluir(poco);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Deletar um rebanho por ID.
        /// </summary>
        /// <param name="id">O Código do rebanho a ser deletado.</param>
        /// <returns>O rebanho que foi deletado.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult<RebanhoPoco> DeleteById(int id)
        {
            try
            {
                RebanhoPoco listResposta = this.servico.Selecionar(id);
                return Ok(listResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}