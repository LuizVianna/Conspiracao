using Conspiracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> Incluir(Item item);
        Task<Item> Alterar(Item item);
        Task<Item> Excluir(int id);
        Task<Item> SelecionarAsync(int id);
        Task<IEnumerable<Item>> SelecionarTodos();
    }
}
