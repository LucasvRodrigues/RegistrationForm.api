using Microsoft.AspNetCore.Mvc;
using RegistrationForm.api.Models;
using RegistrationForm.api.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrationForm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly FuncionarioRepository _repository;

        public FuncionarioController(FuncionarioRepository repository)
        {

            _repository = repository;

        }

        [HttpGet("{id}")]

        public async Task<Funcionario> Get([FromRoute]string id)
        {

            Funcionario funcionario = await new FuncionarioRepository().ConsultarId(id);
            return funcionario;

        }
        [HttpGet]

        public async Task<IEnumerable<Funcionario>> Get()
        {

            var funcionario = await new FuncionarioRepository().ConsultarAll();
            return funcionario;

        }
        [HttpPost]

        public void Post([FromBody] Funcionario funcionario)
        {

            new FuncionarioRepository().Incluir(funcionario);

        }

        // modificar obj inteiro

        [HttpPut]

        public void Put([FromBody] Funcionario funcionario)
        {

            new FuncionarioRepository().Atualizar(funcionario);


        }
        // modificar um parametro do obj
        /*[HttpPatch]
        public Funcionario Patch()
        {
            
        }*/

        //para excluir
        [HttpDelete("{id}")]

        public async Task<Funcionario> Delete([FromRoute]string id)
        {

            Funcionario funcionario = await new FuncionarioRepository().Deletar(id);
            return funcionario;

        }
    }
}
