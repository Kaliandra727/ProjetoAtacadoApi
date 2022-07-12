using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReworkRelatorioController : ControllerBase
    {
        private RelatorioService servico;

        public ReworkRelatorioController()
        {
            this.servico = new RelatorioService();
        }

        /// <summary>
        /// Realiza busca pelos registros através do ID de Categoria.
        /// </summary>
        /// <param name="id">Código a ser pesquisado.</param>
        /// <returns></returns>
        [HttpGet("produto/PorID/{idCategoria:int}")]
        public ActionResult<List<RelatorioPoco>> GetRelatorioCategoriaPorId(int idCategoria)
        {
            try
            {
                List<RelatorioPoco> retorno =  this.servico.ListarPorCategoria(idCategoria);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("subcategoria/PorID/{idSubcategoria:int}")]
        public ActionResult<List<RelatorioPoco>> GetRelatorioSubcategoriaPorId(int idSubcategoria)
        {
            try
            {
                List<RelatorioPoco> retorno = this.servico.ListarPorSubcategoria(idSubcategoria);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Categoria/PorID/{idProduto:int}")]
        public ActionResult<RelatorioPoco> GetRelatorioProdutoPorId(int IdProduto)
        {
            try
            {
                RelatorioPoco retorno = this.servico.ListarPorProduto(IdProduto);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
