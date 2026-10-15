using Microsoft.EntityFrameworkCore;
using Projetodemecanica.api.Models;
using System.Drawing;

namespace Projetodemecanica.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
