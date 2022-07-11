using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        [HttpGet("fichacadastral/{idRebanho:int}")]
        public ActionResult<object> Get(int idRebanho)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from rebs in contexto.Rebanhos
                    where rebs.IdTipoRebanho == idRebanho
                    join muns in contexto.Municipio1s on rebs.IdMunicipio equals muns.CodigoIbge7
                    join est in contexto.UnidadesFederacaos on muns.SiglaUf equals est.SiglaUf
                    select new
                    {
                        IdRebanho = rebs.IdRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IdMunicipio,
                        NomeMunicipio = muns.NomeMunicipio,
                        SiglaUF = est.SiglaUf,
                        NomeEstado = est.DescricaoUf,
                        IdTipoRebanho = rebs.IdTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("pesquisaPorAnoRefIbge{anoRef:int}/{idMun:int}")]
        public ActionResult<List<Object>> GetByAnoRefIbge(int anoRef, int idMun)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from rebs in contexto.Rebanhos
                    where (rebs.AnoRef == anoRef && rebs.IdMunicipio == idMun)
                    join mun in contexto.Municipio1s on rebs.IdMunicipio equals mun.CodigoIbge7
                    join est in contexto.UnidadesFederacaos on mun.SiglaUf equals est.SiglaUf
                    select new
                    {
                        IdRebanho = rebs.IdRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IdMunicipio,
                        NomeMunicipio = mun.NomeMunicipio,
                        SiglaUF = est.SiglaUf,
                        NomeEstado = est.DescricaoUf,
                        IdTipoRebanho = rebs.IdTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("pesquisaPorCategoria/{idCategoria:int}")]
        public ActionResult<object> GetCategoria(int idCategoria)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from cat in contexto.Categorias
                    where (cat.IdCategoria == idCategoria)
                    join sub in contexto.Subcategorias on cat.IdCategoria equals sub.IdCategoria
                    join pro in contexto.Produtos on sub.IdSubcategoria equals pro.IdSubcategoria
                    select new
                    {
                        IdCategoria = cat.IdCategoria,
                        NomeCategoria = cat.DescricaoCategoria,
                        IdSubcategoria = sub.IdSubcategoria,
                        NomeSubcategoria = sub.DescricaoSubcategoria,
                        IdProduto = pro.IdProduto,
                        NomeProduto = pro.DescricaoProduto
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("pesquisaPorSubcategoria/{idSubcategoria:int}")]
        public ActionResult<object> GetPorSubcategoria(int idSubcategoria)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from sub in contexto.Subcategorias
                    where (sub.IdSubcategoria == idSubcategoria)
                    join cat in contexto.Categorias on sub.IdCategoria equals cat.IdCategoria
                    join pro in contexto.Produtos on sub.IdSubcategoria equals pro.IdProduto
                    select new
                    {
                        IdSubcategoria = sub.IdSubcategoria,
                        NomeSubcategoria = sub.DescricaoSubcategoria,
                        IdCategoria = cat.IdCategoria,
                        NomeCategoria = cat.DescricaoCategoria,
                        IdProduto = pro.IdProduto,
                        NomeProduto = pro.DescricaoProduto
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("pesquisaPorProduto/{idProduto:int}")]
        public ActionResult<object> GetPorProduto(int idProduto)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from pro in contexto.Produtos
                    where (pro.IdProduto == idProduto)
                    join cat in contexto.Categorias on pro.IdCategoria equals cat.IdCategoria
                    join sub in contexto.Subcategorias on pro.IdCategoria equals sub.IdSubcategoria
                    select new
                    {
                        IdSubcategoria = sub.IdSubcategoria,
                        NomeSubcategoria = sub.DescricaoSubcategoria,
                        IdCategoria = cat.IdCategoria,
                        NomeCategoria = cat.DescricaoCategoria,
                        IdProduto = pro.IdProduto,
                        NomeProduto = pro.DescricaoProduto
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
