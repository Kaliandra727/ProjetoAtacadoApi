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

        [HttpGet("{skip:int}/{take:int}")]
        public List<FuncionarioPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        [HttpGet("{id:int}")]
        public FuncionarioPoco GetByID(int id)
        {
            return this.servico.Selecionar(id);
        }

        [HttpGet("matricula/{mat:long}")]
        public FuncionarioPoco GetByMatricula(long mat)
        {
            return this.servico.SelecionarPorMatricula(mat);
        }

        [HttpPost]
        public FuncionarioPoco Post([FromBody] FuncionarioPoco poco)
        {
            return this.servico.Criar(poco);
        }

        [HttpPut]
        public FuncionarioPoco Put([FromBody] FuncionarioPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        [HttpDelete]
        public FuncionarioPoco Delete([FromBody] FuncionarioPoco poco)
        {
            return this.servico.Excluir(poco);
        }

        [HttpDelete("{id:int}")]
        public FuncionarioPoco DeleteById(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
