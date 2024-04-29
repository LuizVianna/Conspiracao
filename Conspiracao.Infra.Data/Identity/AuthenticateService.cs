using Conspiracao.Domain.Account;
using Conspiracao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Infra.Data.Identity
{
    internal class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        /// <summary>
        /// Verifica o e-mail e senha do usuário após a digitado
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Verdadeiro/Falso</returns>
        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var usuario = await _context.Usuario
                                .Where(x => x.Email.ToLower() == email.ToLower())
                                .FirstOrDefaultAsync();

            if (usuario == null) return false;

            using var hmac = new HMACSHA3_512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.PasswordHash[i]) return false;
            }

            return true;
        }

        public string GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id",id.ToString()),
                new Claim("email",email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                             _configuration["jwt:secretkey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims = claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<bool> UserExist(string email)
        {
            var usuario = await _context.Usuario
                                .Where(x => x.Email.ToLower() == email.ToLower())
                                .FirstOrDefaultAsync();

            if (usuario == null) return false;

            return true;
        }
    }
}
