using AutoMapper;
using Conspiracao.Application.DTOs;
using Conspiracao.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conspiracao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> Incluir(PedidoDTO pedidoDto)
        {
            var pedidoIncluido = await _pedidoService.Incluir(pedidoDto);
            if (pedidoIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o pedido.");
            }

            return Ok(pedidoIncluido);
        }
    }
}
