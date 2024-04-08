using AutoMapper;
using Conspiracao.Application.DTOs;
using Conspiracao.Application.Interfaces;
using Conspiracao.Domain.Entities;
using Conspiracao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Incluir(PedidoDTO pedidoDto)
        {
            var pedido = await _repository.Incluir(_mapper.Map<Pedido>(pedidoDto));
            var id = Random.Shared.Next(1, 50);
            decimal valorTotal = Pedido.CalculaValorTotalPedido(pedido);
            var itemsPedidos = new List<ItemDTO>();

            foreach (var itemDto in pedidoDto.Itens)
            {
                itemDto.PedidoId = id;
                itemDto.ValorLiquido = CalculaValorLiquidoItem(itemDto);
                itemsPedidos.Add(itemDto);
            }

            var pedidoIncluido = new PedidoDTO
            {
                Id = id,
                NomeFornecedor = pedido.NomeFornecedor.ToUpper(),
                ValorTotal = valorTotal,
                DescontoGeral = pedido.Itens.Sum(x => x.Desconto),
                Itens = _mapper.Map<ICollection<ItemDTO>>(itemsPedidos)
            };

            return _mapper.Map<PedidoDTO>(pedidoIncluido);
        }

        private static decimal CalculaValorLiquidoItem(ItemDTO item)
        {
            return item.Quantidade * item.ValorUnitario - item.Desconto;
        }

    }
}
