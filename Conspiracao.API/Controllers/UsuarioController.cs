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
            if (usuarioDTO == null) return BadRequest("Dados inválidos");

            var emailExiste = await _authenticateService.UserExist(usuarioDTO.Email);

            if (emailExiste) return BadRequest("Este e-mail já está cadastrado.");

            var usuario = await _usuarioService.Incluir(usuarioDTO);

            if (usuario == null) return BadRequest("Ocorreu um erro ao cadastrar!");


            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken { Token = token };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExist(loginModel.Email);
            if (!existe) return Unauthorized("Usuário não existe na base de dados!");

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);

            if (!result) return Unauthorized("Usuário ou senha inválido!");

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }

    }
}
