using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Domain.Entities
{
    public class Item
    {
        public int Id { get;  set; }
        public int PedidoId { get;  set; }
        public int Quantidade { get;  set; }
        public int ValorUnitario { get;  set; }
        public Decimal Desconto { get;  set; }
        public string DescricaoItem { get;  set; }

        public Item(int id, int pedidoId, int quantidade, int valorUnitario, decimal desconto, string descricaoItem)
        {
            ValidateDomain(id, pedidoId, quantidade, valorUnitario, desconto, descricaoItem);
        }


        public void ValidateDomain(int id, int pedidoId, int quantidade, int valorUnitario, decimal desconto, string descricaoItem)
        {
            Id = id;
            PedidoId = pedidoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Desconto = desconto;
            DescricaoItem = descricaoItem;
        }
    }
}
