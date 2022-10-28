using System.ComponentModel.DataAnnotations;

namespace salaodebeleza.Models;
public class Servico {

    [Key]
    public int ID { get; set; }

    [Required(ErrorMessage = "O preço deve ser informado!")]
    public double Preco { get; set; }

    [Required(ErrorMessage = "O campo de descrição precisa ser preenchido!")]
    public string Descricao { get; set; }
}
