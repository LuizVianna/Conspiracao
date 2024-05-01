using System.ComponentModel.DataAnnotations;

namespace Conspiracao.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="O e-mail é obrgatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrgatório!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
