using Conspiracao.Domain.Entities;
using Conspiracao.Domain.Interfaces;
using Conspiracao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Item> Alterar(Item item)
        {
            _context.Item.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> Excluir(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Item> Incluir(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task<Item> SelecionarAsync(int id)
        {
            return await _context.Item.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Item>> SelecionarTodos()
        {
            return await _context.Item.ToListAsync();
        }
    }
}
