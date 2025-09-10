using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServico.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        [HttpGet]
        public IActionResult Principal()
        {
            var resultado = new { situacao = "Ok", mensagem = "Api Serviço" };

            return Ok(resultado);
        }

        [HttpGet("autor")]
        public IActionResult GetAutor()
        {
            return Ok(new
            {
                nome = "Joao Teixeira",
                email = "joao.teixeira@ifro.edu.br",
                telefone = "999"
            });
        }
    }
}
