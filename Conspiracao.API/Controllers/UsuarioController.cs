using Conspiracao.API.Models;
using Conspiracao.Application.DTOs;
using Conspiracao.Application.Interfaces;
using Conspiracao.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace Conspiracao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("Dados inválidos.");

            var emailExiste = await _authenticateService.UserExist(usuarioDTO.Email);

            if (emailExiste) return BadRequest("Este e-mail já está cadastrado na base!");

            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if (usuario == null) return BadRequest("Ocorreu um erro ao cadastrar.");

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
