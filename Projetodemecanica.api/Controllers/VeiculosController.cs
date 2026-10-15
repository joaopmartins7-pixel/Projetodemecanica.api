using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetodemecanica.api.Data;
using Projetodemecanica.api.Models;

namespace Projetodemecanica.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostVeiculos(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo cadastrado com sucesso!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarVeiculo(int id, Veiculo veiculo)
        {
            var veiculoAtual = await _context.Veiculos.FindAsync(id);
            if (veiculoAtual == null)
            {
                return NotFound();
            }

            veiculoAtual.Placa = veiculo.Placa;
            veiculoAtual.Modelo = veiculo.Modelo;
            veiculoAtual.Marca = veiculo.Marca;
            veiculoAtual.ClienteId = veiculo.ClienteId;

            await _context.SaveChangesAsync();

            return Ok("Veículo alterado com sucesso");
        }

    }
}
