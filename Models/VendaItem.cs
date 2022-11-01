using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace salaodebeleza.Models
{
    public class VendaItem
    {
        public VendaItem()
        {

        }
        public VendaItem(double preco, int servicoID, double quantidade, Servico servico)
        {
            Preco = preco;
            ServicoID = servicoID;
            Servico = servico;
            Quantidade = quantidade;
        }

        [Key]
        public int ID { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser informado.")]
        public double Preco { get; set; }

        [Range(1, int.MaxValue)]
        [ForeignKey("ServicoID")]
        public int ServicoID { get; set; }
        public Servico Servico { get; set; }

        [ForeignKey("VendaID")]
        public int VendaID { get; set; }
        public Venda Venda { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Quantidade { get; set; }

        public double ValorTotal() =>
        Preco * Quantidade;
    }
}