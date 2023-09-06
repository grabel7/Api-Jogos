using VideoJogos.Models;
using VideoJogos.Services;
using Microsoft.AspNetCore.Mvc;

namespace VideoJogos.Controllers;

[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
    public JogoController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Jogo>> GetAll() =>
    JogoService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Jogo> Get(int id){
        var jogo = JogoService.Get(id);

        if (jogo == null)
            return NotFound($"Não foi encontrado jogo com o id {id}");
            
            return jogo;
    }


    // POST action
    [HttpPost]
    public IActionResult Create(Jogo jogo){
        JogoService.Add(jogo);
        return CreatedAtAction(nameof(Get), new { id = jogo.Id}, jogo);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Jogo jogo){

        if (id != jogo.Id)
            return BadRequest("Solicitação Inexistente");

        var jogoExistente = JogoService.Get(id);
        if(jogoExistente is null)
            return NotFound($"Não foi encontrado jogo com o id {id}");

        JogoService.Update(jogo);
        
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete (int id){
        var jogo = JogoService.Get(id);

        if (jogo is null)
            return NotFound($"Não foi encontrado jogo com o id {id}");

        JogoService.Delete(id);

        return NoContent();
    }

    [HttpGet("{id}/historico")]
        public ActionResult<List<HistoricoAtualizacao>> GetHistoricoAtualizacoes(int id)
        {
            var jogo = JogoService.Get(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return jogo.HistoricoAtualizacoes;
        }
}