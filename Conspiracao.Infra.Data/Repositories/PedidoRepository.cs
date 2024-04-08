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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Pedido> Incluir(Pedido pedido)
        {
            //NÃO TEM A NECESSIDADE DE USAR BANCO DE DADOS
            //_context.Pedido.Add(pedido);
            //await _context.SaveChangesAsync();

            return pedido;

        }
    }
}
