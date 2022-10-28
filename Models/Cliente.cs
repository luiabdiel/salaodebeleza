using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace salaodebeleza.Models;
public class Cliente {
	public Cliente()
	{
        DataNascimento = DateTime.Now;
    }

    [Key]
    public int ID { get; set; }

    [Required(ErrorMessage = "O campo de usuário é obrigatório")]
    [StringLength(60, MinimumLength = 3)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Dígite um CPF válido")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "Dígite um CPF válido")]
    public string CPF { get; set; }

    public DateTime DataNascimento { get; set; }
    public List<Venda> Vendas { get; set; }

}

