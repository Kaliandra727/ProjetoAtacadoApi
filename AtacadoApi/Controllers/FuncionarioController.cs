using Atacado.Poco.RH;
using Atacado.Service.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/rh/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioService servico;

        public FuncionarioController() : base()
        {
            this.servico = new FuncionarioService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip">Variável que irá receber o valor para pular.</param>
        /// <param name="take">Variável que vai receber o numero de informações para exibir.</param>
        /// <returns></returns>

        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<FuncionarioPoco>> GetAll(int skip, int take)
        {
            try
            {
                List<FuncionarioPoco> listResposta = this.servico.Listar(skip, take);
                return Ok(listResposta);

            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpGet("{id:int}")]
        public ActionResult<FuncionarioPoco> GetByID(int id)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Selecionar(id);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>

        [HttpGet("matricula/{mat:long}")]
        public ActionResult<FuncionarioPoco> GetByMatricula(long mat)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.SelecionarPorMatricula(mat);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>


        [HttpPost]
        public ActionResult<FuncionarioPoco> Post([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Criar(poco);

                if (pocoResposta == null)
                {
                    return BadRequest(this.servico.MensagemProcessamento);
                }
                else
                {
                    return Ok(pocoResposta);
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>

        [HttpPut]
        public ActionResult<FuncionarioPoco> Put([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Atualizar(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
       
        [HttpDelete]
        public ActionResult<FuncionarioPoco> Delete([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Excluir(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpDelete("{id:int}")]
        public ActionResult<FuncionarioPoco> DeleteById(int id)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Excluir(id);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
