using System.ComponentModel.DataAnnotations;

namespace salaodebeleza.Models;
public class Servico {

    [Key]
    public int ID { get; set; }

    [Required]
    public double Preco { get; set; }

    [Required]
    public string Descricao { get; set; }

    
}
