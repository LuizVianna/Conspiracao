using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Application.DTOs
{
    public class ItemDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PedidoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public int ValorUnitario { get; set; }
        [Required]
        public Decimal Desconto { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "A descrição do item deve terno máximo 100 caracteres.")]
        public string DescricaoItem { get; set; } = string.Empty;

        public decimal ValorLiquido { get; set; }
    }
}
