using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salaodebeleza.Models;
public class Venda
{
    public Venda()
    {
        DataEmissao = DateTime.Now;
        Itens = new();
    }

    [Key]
    public int ID { get; set; }

    public DateTime DataEmissao { get; set; }

    [Range(1, int.MaxValue)]
    [ForeignKey("ClienteID")]
    public int ClienteID { get; set; }

    public Cliente Cliente { get; set; }

    public double ValorTotal() =>
        Itens.Sum(item => item.ValorTotal());
    
    public List<VendaItem> Itens { get; set; }
}
