using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salaodebeleza.Models
{
    public class Agendamento
    {
        [Key]
        public int ID { get; set; }

        [Range(1, int.MaxValue)]
        [ForeignKey("ClienteID")]
        public int ClienteID { get; set; }

        [Required]
        public DateTime DataAgendamento { get; set; }

    }
}
