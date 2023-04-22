using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class Estados_reserva
    {
        [Key]
        public int estados_res_id { get; set; }
        public string? estado { get; set; }
    }
}