using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetodemecanica.api.Data;
using Projetodemecanica.api.Models;

namespace Projetodemecanica.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.usuario == usuario.usuario && u.Senha == usuario.Senha);

            if (user == null)
            {
                return Unauthorized("usuário ou senha incorretos. verifique por favor!");
            }

            return Ok(new {Nome = user.Nome});
        }
    }
}
