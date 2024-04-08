using Conspiracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> Incluir(Pedido item);
    }
}
