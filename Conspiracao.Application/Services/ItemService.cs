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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ItemDTO> Alterar(ItemDTO itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            var itemAlterado = await _repository.Alterar(item);
            return _mapper.Map<ItemDTO>(itemDto);
        }

        public async Task<ItemDTO> Excluir(int id)
        {
            var itemExcluido = await _repository.Excluir(id);
            return _mapper.Map<ItemDTO>(itemExcluido);
        }

        public async Task<ItemDTO> Incluir(ItemDTO itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            var itemIncluido = await _repository.Incluir(item);
            return _mapper.Map<ItemDTO>(itemIncluido);
        }

        public async Task<IEnumerable<ItemDTO>> SelecionarTodos()
        {
            var itens = await _repository.SelecionarTodos();
            return _mapper.Map<IEnumerable<ItemDTO>>(itens);
        }
    }
}
