using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dominio.Entidade.Usuario;
using Dominio.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Servico.Interface.Token;

namespace Servico.Servico.Token
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GenerateToken(UsuarioSistema usuario)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),  // <-- correto aqui
            new Claim("Name", usuario.NomeUsuario),
            new Claim("Character", usuario.CharacterName),
            new Claim(ClaimTypes.Name, usuario.NomeUsuario),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSettings.Secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int GetIdUsuarioLogado()
        {
            string? token = _contextAccessor.HttpContext?.Request?.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException("Token não encontrado no cabeçalho Authorization.");

            var principal = GetPrincipalFromToken(token);

            var claim = principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                        ?? throw new UnauthorizedAccessException("Claim de usuário não encontrada.");

            return int.Parse(claim.Value);
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.ASCII.GetBytes(TokenSettings.Secret);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(byteKey)
            };

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken _);
            return principal;
        }
    }

}
