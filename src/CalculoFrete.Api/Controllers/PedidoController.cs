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
            var pedido = await _pedidoService.ObterCompletoPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(_mapper.Map<ConsultarPedidoVm>(pedido));
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ConsultarPedidoVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ObterTodos()
        {
            var pedidos = await _pedidoService.ObterTodosAsync();

            if (pedidos == null || !pedidos.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<ConsultarPedidoVm>>(pedidos));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarPedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = new Pedido(model.ClienteId);
            var itensPedido = model.Itens.Select(item => new ItemPedido(pedido.Id, item.ProdutoId, item.FreteSelecionado.ModalidadeFrete, item.FreteSelecionado.DataAgendamento));
            pedido.AtualizarItens(itensPedido);
            pedido = await _pedidoService.Adicionar(pedido);
            return CreatedAtAction(nameof(ObterPorId), new { id = pedido.Id }, pedido);
        }

        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] AtualizarPedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = await _pedidoService.Atualizar(model.Id, model.NovoCep);
            return Ok(_mapper.Map<ConsultarPedidoVm>(pedido));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remover([FromRoute] Guid id)
        {
            await _pedidoService.Remover(id);
            return Ok();
        }

        [HttpPost("calcular-frete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalcularFrete([FromBody] AdicionarPedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var pedido = _mapper.Map<Pedido>(model);
            var freteCalculado = await _pedidoService.CalcularFreteDoPedido(pedido);

            return Ok(freteCalculado);
        }
    }
}
