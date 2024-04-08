using Conspiracao.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public string NomeFornecedor { get; private set; }
        public decimal DescontoGeral { get; private set; }

        public ICollection<Item> Itens { get; set; }
        public Pedido()
        {
            Itens = new List<Item>();
        }

        public Pedido(int id, string nomeFornecedor, decimal descontoGeral, ICollection<Item> itens)
        {
            Id = new Random().Next(1, 50);
            ValidateDomain(nomeFornecedor, descontoGeral, itens);
        }

        public Pedido(string nomeFornecedor, decimal descontoGeral, ICollection<Item> itens)
        {
            DomainExceptionValidation.When(nomeFornecedor.Length < 3 || nomeFornecedor.Length > 200, "Nome Fornecedor deve ter no mínimo de 3 e no máximo 200 caracteres.");

            ValidateDomain(nomeFornecedor, descontoGeral, itens);
        }

        public void ValidateDomain(string nomeFornecedor, decimal descontoGeral, ICollection<Item> itens)
        {
            NomeFornecedor = nomeFornecedor;
            DescontoGeral = descontoGeral;
            Itens = itens;
        }

        public static decimal CalculaValorTotalPedido(Pedido pedido)
        {
            decimal valorTotal = 0;
            foreach (var item in pedido.Itens)
            {
                valorTotal += item.Quantidade * item.ValorUnitario - item.Desconto;
            }

            return valorTotal;
        }
    }
}
