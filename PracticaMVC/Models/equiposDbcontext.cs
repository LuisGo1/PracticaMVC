using Microsoft.EntityFrameworkCore;

namespace PracticaMVC.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Estados_equipo> Estados_Equipos { get; set; }
        public DbSet<Estados_reserva> Estado_reserva { get; set; }
        public DbSet<Facultades> Facultades { get; set; }
        public DbSet<Tipo_equipo> Tipo_equipo { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }

}