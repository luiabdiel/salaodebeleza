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

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Nome { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14)]
    public string CPF { get; set; }

    public DateTime DataNascimento { get; set; }
}

