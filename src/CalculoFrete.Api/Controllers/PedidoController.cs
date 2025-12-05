using AutoMapper;
using CalculoFrete.Api.Models;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculoFrete.Api.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        readonly IPedidoService _pedidoService;
        readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ConsultarPedidoVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var pedido = await _pedidoService.ObterPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ConsultarPedidoVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ConsultarPedidoVm>), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Listar()
        {
            var pedidos = await _pedidoService.ObterTodosAsync();

            if (pedidos == null || !pedidos.Any())
                return NoContent();

            return Ok(pedidos);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarPedidoVm model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = await _pedidoService.Adicionar(_mapper.Map<Pedido>(model));
            return CreatedAtAction(nameof(ObterPorId), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] AtualizarPedidoVm model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = await _pedidoService.Atualizar(_mapper.Map<Pedido>(model));
            return Ok(pedido);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remover([FromRoute] Guid id)
        {
            await _pedidoService.Remover(id);
            return Ok();
        }
    }
}
