using Conspiracao.API.Models;
using Conspiracao.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Conspiracao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {
            return View();
        }
    }
}
