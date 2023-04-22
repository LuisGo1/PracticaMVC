using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class Estados_equipo
    {
        [Key]
        public int id_estados_equipos { get; set; }
        public string? descripcion { get; set; }
        public string? estado { get; set; }

    }
}