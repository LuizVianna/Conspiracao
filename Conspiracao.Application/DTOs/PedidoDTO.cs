using Conspiracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Application.DTOs
{
    public class PedidoDTO
    {
        [Required]
        public int Id { get;  set; }

        [Required]
        [StringLength(200, ErrorMessage = "O nome do Fornecedor deve ter 200 caracteres.")]
        public string NomeFornecedor { get;  set; }
        [Required]
        public decimal DescontoGeral { get;  set; }

        public decimal ValorTotal { get; set; }

        public ICollection<ItemDTO> Itens { get; set; }
    }
}
