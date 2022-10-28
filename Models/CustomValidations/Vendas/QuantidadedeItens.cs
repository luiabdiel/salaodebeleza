using System.ComponentModel.DataAnnotations;

namespace salaodebeleza.Models.CustomValidations.Vendas;
public class QuantidadeItens : ValidationAttribute
{

    Venda Venda { get; set; }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        Venda = (Venda)validationContext.ObjectInstance;
        return TemItens() ? ValidationResult.Success : new ValidationResult("Venda deve ter itens inseridos.");
    }

    bool TemItens() => Venda.Itens?.Any() ?? false;
}