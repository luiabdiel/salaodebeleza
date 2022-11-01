using System.ComponentModel.DataAnnotations;

namespace salaodebeleza.Models;
public class Servico {

    [Key]
    public int ID { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser informado.")]
    public double Preco { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public int Tipo { get; set; }

    public double Quantidade { get; set; }

    public List<VendaItem> Itens { get; set; }
}
