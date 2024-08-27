using Moq;
using CalculadoraSeguros.Domain.Commands;
using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Domain.Repositories;
using CalculadoraSeguros.Shared.Commands;
using CalculadoraSeguros.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CalculadoraSeguros.TestesUnitarios.API;

public class CalculoSeguroControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ICalculoSeguroRepository> _calculoSeguroRepositoryMock;
    private readonly CalculoSeguroController _controller;

    public CalculoSeguroControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _calculoSeguroRepositoryMock = new Mock<ICalculoSeguroRepository>();
        _controller = new CalculoSeguroController(_mediatorMock.Object, _calculoSeguroRepositoryMock.Object);
    }

    [Fact]
    public async Task Post_ReturnsBadRequest_WhenResultIsNotSuccess()
    {
        // Arrange
        var command = new CalcularSeguroCommand(null, null, 0, 0, null, null);
        var result = new CommandResult { Sucesso = false, Dados = "Erro" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<CalcularSeguroCommand>(), default))
                     .ReturnsAsync(result);

        // Act
        var response = await _controller.Post(command);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
        Assert.Equal("Erro", badRequestResult.Value);
    }

    [Fact]
    public async Task Post_ReturnsOk_WhenResultIsSuccess()
    {
        // Arrange
        var command = new CalcularSeguroCommand("Admin Teste", "123", 20, 10000, "GM", "ONIX");
        var calculoSeguro = new CalculoSeguro();
        var result = new CommandResult { Sucesso = true, Dados = calculoSeguro };

        _mediatorMock.Setup(m => m.Send(It.IsAny<CalcularSeguroCommand>(), default))
                     .ReturnsAsync(result);

        // Act
        var response = await _controller.Post(command);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(calculoSeguro, okResult.Value);
    }

    [Fact]
    public async Task Get_ReturnsOkWithAllCalculosSeguro()
    {
        // Arrange
        var calculosSeguro = new List<CalculoSeguro>
            {
                new(),
                new()
            };

        _calculoSeguroRepositoryMock.Setup(r => r.ObterTodos())
                                    .ReturnsAsync(calculosSeguro);

        // Act
        var response = await _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(calculosSeguro, okResult.Value);
    }

    [Fact]
    public async Task Get_ReturnsNotFound_WhenCalculoSeguroDoesNotExist()
    {
        // Arrange
        var id = Guid.NewGuid();
        _calculoSeguroRepositoryMock.Setup(r => r.ObterPorId(id))
                                    .ReturnsAsync((CalculoSeguro)null);

        // Act
        var response = await _controller.Get(id);

        // Assert
        Assert.IsType<NotFoundResult>(response);
    }

    [Fact]
    public async Task Get_ReturnsOkWithCalculoSeguro_WhenCalculoSeguroExists()
    {
        // Arrange
        var calculoSeguro = new CalculoSeguro();

        _calculoSeguroRepositoryMock.Setup(r => r.ObterPorId(calculoSeguro.Id))
                                    .ReturnsAsync(calculoSeguro);

        // Act
        var response = await _controller.Get(calculoSeguro.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(calculoSeguro, okResult.Value);
    }
}