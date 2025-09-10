using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServico.Models.Dtos;
using ApiServico.Models;

namespace ApiServico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {

        private static List<Chamado> _listaChamados = new List<Chamado>
        {
            new Chamado() { 
                Id = 1, Titulo = "Erro na Tela de Acesso", Descricao = "O usuário não conseguiu logar" },
            new Chamado() { 
                Id = 2, Titulo = "Sistema com lentidão", Descricao = "Demora no carregamento das telas"}
        };

        private static int _proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(_listaChamados);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(item => item.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ChamadoDto novoChamado)
        {

            var chamado = new Chamado
            {
                Id = _proximoId++,
                Titulo = novoChamado.Titulo,
                Descricao = novoChamado.Descricao,
                Status = "Aberto"
            };

            _listaChamados.Add(chamado);

            return Created("", chamado);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] ChamadoDto novoChamado)
        {
            var chamado = _listaChamados.FirstOrDefault(item => item.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            chamado.Titulo = novoChamado.Titulo;
            chamado.Descricao = novoChamado.Descricao;

            return Ok(chamado);
        }

        [HttpPost("{id}/fechamento")]
        public IActionResult FecharChamado(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(item => item.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            chamado.Status = "Fechado";
            chamado.DataFechamento = DateTime.Now;

            return Ok(chamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(item => item.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            _listaChamados.Remove(chamado);

            return NoContent();
        }
    }
}
