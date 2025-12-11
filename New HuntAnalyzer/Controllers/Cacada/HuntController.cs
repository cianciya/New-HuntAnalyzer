using Dominio.Entidade.Cacada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Servico.Interface.Cacada;
using Servico.Interface.Token;
using Servico.Servico.Token;

namespace New_HuntAnalyzer.Controllers.Cacada
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HuntController
    {
        private readonly IHuntService _service;
        private readonly ITokenService _tokenService;

        public HuntController(IHuntService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] HuntDto dto)
        {

            Hunt hunt = await _service.CreateAsync(dto, _tokenService.GetIdUsuarioLogado());
            return Ok(hunt);
        }
    }
}
