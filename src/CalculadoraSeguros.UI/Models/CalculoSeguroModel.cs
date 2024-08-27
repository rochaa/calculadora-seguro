namespace CalculadoraSeguros.UI.Models;

public class CalculoSeguro
{
    public Guid SeguradoId { get; set; }
    public Guid VeiculoId { get; set; }
    public decimal TaxaRisco { get; set; }
    public decimal PremioRisco { get; set; }
    public decimal PremioPuro { get; set; }
    public decimal PremioComercial { get; set; }
    public decimal MargemSeguranca { get; set; }
    public decimal Lucro { get; set; }
    public decimal ValorSeguro { get; set; }
    public Segurado Segurado { get; set; }
    public Veiculo Veiculo { get; set; }
}

public class Segurado
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public Guid Id { get; set; }
}

public class Veiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public decimal Valor { get; set; }
    public Guid Id { get; set; }
}