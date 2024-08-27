using CalculadoraSeguros.Domain.Commands;
using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Domain.Repositories;
using CalculadoraSeguros.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraSeguros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoSeguroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICalculoSeguroRepository _calculoSeguroRepository;

        public CalculoSeguroController(
            IMediator mediator,
            ICalculoSeguroRepository calculoSeguroRepository)
        {
            _mediator = mediator;
            _calculoSeguroRepository = calculoSeguroRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalcularSeguroCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Sucesso)
                return BadRequest(result.Dados);

            return Ok((CalculoSeguro)result.Dados);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var calculosSeguro = await _calculoSeguroRepository.ObterTodos();

            return Ok(calculosSeguro);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var calculoSeguro = await _calculoSeguroRepository.ObterPorId(id);

            if (calculoSeguro == null)
                return NotFound();

            return Ok(calculoSeguro);
        }
    }
}
