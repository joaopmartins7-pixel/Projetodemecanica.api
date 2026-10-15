using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetodemecanica.api.Data;
using Projetodemecanica.api.Models;

namespace Projetodemecanica.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAgendamento(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Agendamento cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarAgendamento(int id, Agendamento agendamento)
        {
            var agendamentoAtual = await _context.Agendamentos.FindAsync(id);
            if (agendamentoAtual == null)
            {
                return NotFound();
            }

            agendamentoAtual.Data = agendamento.Data;
            agendamentoAtual.Hora = agendamento.Hora;
            agendamentoAtual.Serviço = agendamento.Serviço;

            await _context.SaveChangesAsync();

            return Ok("Agendamento alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return Ok("Agendamento deletado com sucesso!");
        }
    }
}

