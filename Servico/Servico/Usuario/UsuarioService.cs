using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidade.Usuario;
using Dominio.Entidade.Usuario.UsuarioDto;
using Dominio.Entidade.Usuario.UsuarioViewModel;
using Dominio.Interface.Usuario;
using Servico.Interface.Token;
using Servico.Interface.Usuario;

namespace Servico.Servico.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioSistemaRespostaViewModel> AuthenticateAsync(LoginUsuarioSistemaDto dto)
        {
            UsuarioSistema usuario = await _repository.GetByUserNameAsync(dto.NomeUsuario);
            //if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.PasswordHash, usuario.PasswordHash))
            //    return null;

            string token = _tokenService.GenerateToken(usuario);

            return new UsuarioSistemaRespostaViewModel
            {
                NomeUsuario = usuario.NomeUsuario,
                CharacterName = usuario.CharacterName,
                Token = token,
                Message = "Login realizado com sucesso!"
            };
        }

        public async Task<RegistroUsuarioSistemaViewModel> CreateAsync(RegistroUsuarioSistemaDto dto)
        {
            try
            {
                UsuarioSistema usuarioExiste = await _repository.GetByUserNameAsync(dto.NomeUsuario);
                if (usuarioExiste != null)
                    throw new Exception("Usuario já existe.");

                //string senhaCriptografada = BCrypt.Net.BCrypt.HasPassword(dto.PasswordHash);

                UsuarioSistema novoUsuario = new UsuarioSistema
                {
                    NomeUsuario = dto.NomeUsuario,
                    PasswordHash = dto.PasswordHash,
                    CharacterName = dto.CharacterName
                };

                await _repository.CreatAsync(novoUsuario);
                RegistroUsuarioSistemaViewModel novo = _mapper.Map<RegistroUsuarioSistemaViewModel>(novoUsuario);
                novo.Message = $"Usuario {dto.NomeUsuario} criado com sucesso!";
                return novo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
