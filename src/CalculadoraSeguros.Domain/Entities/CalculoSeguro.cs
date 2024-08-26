using CalculadoraSeguros.Shared.Entities;

namespace CalculadoraSeguros.Domain.Entities
{
    public class CalculoSeguro : Entity, IAggregateRoot
    {
        public Guid SeguradoId { get; private set; }
        public Guid VeiculoId { get; private set; }
        public decimal TaxaRisco { get; private set; }
        public decimal PremioRisco { get; private set; }
        public decimal PremioPuro { get; private set; }
        public decimal PremioComercial { get; private set; }
        public decimal MargemSeguranca { get; private set; }
        public decimal Lucro { get; private set; }
        public decimal ValorSeguro { get; private set; }

        public Segurado Segurado { get; private set; }
        public Veiculo Veiculo { get; private set; }

        public CalculoSeguro(string nome, string cpf, int idade, string marca, string modelo, decimal valorVeiculo)
        {
            AdicionarSegurado(nome, cpf, idade);
            AdicionarVeiculo(marca, modelo, valorVeiculo);
            CalcularPremios();
        }

        private void AdicionarSegurado(string nome, string cpf, int idade)
        {
            Segurado = new Segurado(nome, cpf, idade);
        }

        private void AdicionarVeiculo(string marca, string modelo, decimal valorVeiculo)
        {
            Veiculo = new Veiculo(marca, modelo, valorVeiculo);
        }

        private void CalcularPremios()
        {
            const int MARGEM_SEGURANCA_PERCENTUAL = 3;
            const int LUCRO_PERCENTUAL = 5;

            TaxaRisco = Veiculo.Valor * 5 / (2 * Veiculo.Valor);
            PremioRisco = TaxaRisco * Veiculo.Valor / 100;
            PremioPuro = PremioRisco * (1 + MARGEM_SEGURANCA_PERCENTUAL / 100);
            PremioComercial = LUCRO_PERCENTUAL / 100 * PremioPuro + PremioPuro;
            ValorSeguro = PremioComercial;
        }
    }

}
