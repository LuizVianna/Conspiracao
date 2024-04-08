using Conspiracao.Application.DTOs;
using Conspiracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoDTO> Incluir(PedidoDTO item);
    }
}
