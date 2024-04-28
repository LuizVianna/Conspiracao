using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Application.DTOs
{
    public class UsuarioDTO
    {
        // public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O e-mail não pode ter mais de 200 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O senha é obrigatória.")]
        [MaxLength(100, ErrorMessage = "O senha deve ter, no máximo, de 100 caracteres.")]
        [MinLength(8, ErrorMessage = "O senha deve ter no mínimo, de 8 caracteres.")]
        [NotMapped]
        public string Password { get; set; }

    }
}
