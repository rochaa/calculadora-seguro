using Moq;
using CalculadoraSeguros.Domain.Commands;
using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Domain.Repositories;
using global::CalculadoraSeguros.Domain.Handlers;
using CalculadoraSeguros.Shared.Data;

namespace CalculadoraSeguros.TestesUnitarios.Domain;

public class CalcularSeguroHandlerTests
{
    private readonly Mock<ICalculoSeguroRepository> _calculoSeguroRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly CalcularSeguroHandler _handler;

    public CalcularSeguroHandlerTests()
    {
        _calculoSeguroRepositoryMock = new Mock<ICalculoSeguroRepository>();

        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _calculoSeguroRepositoryMock.Setup(r => r.UnitOfWork).Returns(_unitOfWorkMock.Object);

        _handler = new CalcularSeguroHandler(_calculoSeguroRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnError_WhenCommandIsInvalid()
    {
        // Arrange
        var command = new CalcularSeguroCommand("", "", 0, 0, "", "");
        command.Validar();

        // Act
        var result = await _handler.Handle(command);

        // Assert
        Assert.False(result.Sucesso);
        Assert.Equal("Dados para calcular o seguro inválido", result.Mensagem);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryMethods_WhenCommandIsValid()
    {
        // Arrange
        var command = new CalcularSeguroCommand("João", "12345678900", 30, 50000, "Toyota", "Corolla");

        // Act
        var result = await _handler.Handle(command);

        // Assert
        _calculoSeguroRepositoryMock.Verify(r => r.AdicionarSegurado(It.IsAny<Segurado>()), Times.Once);
        _calculoSeguroRepositoryMock.Verify(r => r.AdicionarVeiculo(It.IsAny<Veiculo>()), Times.Once);
        _calculoSeguroRepositoryMock.Verify(r => r.AdicionarCalculoSeguro(It.IsAny<CalculoSeguro>()), Times.Once);
        _calculoSeguroRepositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Once);

        Assert.True(result.Sucesso);
        Assert.Equal("Calculo do seguro realizado com sucesso.", result.Mensagem);
    }

    [Fact]
    public async Task Handle_ShouldReturnValidCommandResult_WhenCommandIsValid()
    {
        // Arrange
        var command = new CalcularSeguroCommand("Maria", "98765432100", 25, 30000, "Honda", "Civic");

        // Act
        var result = await _handler.Handle(command);
        var calculoSeguro = result.Dados as CalculoSeguro;

        // Assert
        Assert.True(result.Sucesso);
        Assert.NotNull(result.Dados);
        Assert.NotNull(calculoSeguro);
        Assert.Equal("Maria", calculoSeguro.Segurado.Nome);
        Assert.Equal("98765432100", calculoSeguro.Segurado.Cpf);
        Assert.Equal(25, calculoSeguro.Segurado.Idade);
        Assert.Equal("Honda", calculoSeguro.Veiculo.Marca);
        Assert.Equal("Civic", calculoSeguro.Veiculo.Modelo);
        Assert.Equal(30000, calculoSeguro.Veiculo.Valor);
    }
}
