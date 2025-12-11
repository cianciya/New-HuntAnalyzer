using Dominio.Entidade.Usuario.UsuarioDto;
using Dominio.Entidade.Usuario.UsuarioViewModel;
using Microsoft.AspNetCore.Mvc;
using Servico.Interface.Usuario;

namespace New_HuntAnalyzer.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistroUsuarioSistemaDto dto)
        {
            RegistroUsuarioSistemaViewModel result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        //[HttpGet("{userName}")]
        //public async Task<IActionResult> GetByUserName(string userName)
        //{
        //    var user = await _service.GetByUserNameAsync(userName);
        //    if (user == null) return NotFound();
        //    return Ok(user);
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioSistemaDto dto)
        {
            UsuarioSistemaRespostaViewModel result = await _service.AuthenticateAsync(dto);
            if (result == null)
                return Unauthorized("Usuário ou senha inválidos.");
            return Ok(result);
        }
    }
}
