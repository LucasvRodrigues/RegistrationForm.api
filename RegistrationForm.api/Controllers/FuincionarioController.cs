using Microsoft.AspNetCore.Mvc;
using RegistrationForm.api.Models;
using RegistrationForm.api.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrationForm.api.Controllers
{
    [Route("api/Funcionario")]
    [ApiController]

    public class FuncionarioController : ControllerBase
    {
        private FuncionarioRepository _funcionarioRepository;

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get([FromRoute] int id)
        {

            try
            {

                Funcionario funcionario = await _funcionarioRepository.ConsultarId(id);
                if (funcionario == null)
                {
                    return BadRequest("Este funcionario nao esta cadastrado");
                }
                return Ok(funcionario);

            }
            catch (System.Exception)
            {
                
                return BadRequest("Ocorreu um erro tente mais tarde");

            }

        }

        [HttpGet]

        public async Task<IEnumerable<Funcionario>>  Get()
        {

                var funcionario = await _funcionarioRepository.ConsultarAll();
                return funcionario;

        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] Funcionario funcionario)
        {

            try
            {
                var novofuncionario = await _funcionarioRepository.Incluir(funcionario);
                return Ok("funcionario incluido com sucesso!");

            }
            catch (System.Exception)
            {

                return BadRequest("Ocorreu um erro, tente mais tarde");

            }

            

        }

        // modificar obj inteiro

        [HttpPut]

        public async Task<IActionResult> Put([FromBody] Funcionario funcionario)
        {

            try
            {

                var put = await _funcionarioRepository.Atualizar(funcionario);
                return Ok("Alteração realizada com sucesso");

            }
            catch (System.Exception)
            {

                return BadRequest("Ocorreu um erro, tente mais tarde");
            }
            

        }
        // modificar um parametro do obj
        /*[HttpPatch]
        public Funcionario Patch()
        {
            
        }*/

        //para excluir
        [HttpDelete("{id}")]

        public void Delete([FromRoute] int id)
        {

            _funcionarioRepository.Deletar(id);

        }
    }
}
