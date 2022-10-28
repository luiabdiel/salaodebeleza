using salaodebeleza.Models.CustomValidations.Vendas;
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

    [QuantidadeItens]
        public List<VendaItem> Itens { get; set; }


    }
}
