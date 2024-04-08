using Conspiracao.Application.DTOs;
using Conspiracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Application.Interfaces
{
    public interface IItemService
    {
        Task<ItemDTO> Incluir(ItemDTO item);
         Task<ItemDTO> Alterar(ItemDTO item);
        Task<ItemDTO> Excluir(int id);
        Task<IEnumerable<ItemDTO>> SelecionarTodos();
    }
}
