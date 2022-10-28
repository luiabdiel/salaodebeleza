using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salaodebeleza.Models {
    public class Venda {

        public Venda()
        {
            DataDeEmissao = DateTime.Now;
        }

        [Key]
        public int ID { get; set; }

        public DateTime DataDeEmissao { get; set; }

        [Range(1, int.MaxValue)]
        [ForeignKey("ClienteID")]
        public int ClienteID { get; set; }

        public Cliente Cliente { get; set; }

        //[QuantidadeItens]
        public List<VendaItem> Itens { get; set; }
    }
}
