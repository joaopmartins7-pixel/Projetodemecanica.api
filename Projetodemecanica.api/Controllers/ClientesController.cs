using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetodemecanica.api.Data;
using Projetodemecanica.api.Models;

namespace Projetodemecanica.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente cadastrado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarCliente(int id, Cliente cliente)
        {
            var clienteAtual = await _context.Clientes.FindAsync(id);
            if (clienteAtual == null)
            {
                return NotFound();
            }

            clienteAtual.Nome = cliente.Nome;
            clienteAtual.Email = cliente.Email;
            clienteAtual.Telefone = cliente.Telefone;
            clienteAtual.Endereco = cliente.Endereco;

            await _context.SaveChangesAsync();

            return Ok("Cliente alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente deletado com sucesso!");
        }
    }
}
