using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Usuario.UsuarioDto;
using Dominio.Entidade.Usuario.UsuarioViewModel;
using Dominio.Interface.Usuario;

namespace Servico.Interface.Usuario
{
    public interface IUsuarioService
    {
        Task<UsuarioSistemaRespostaViewModel> AuthenticateAsync(LoginUsuarioSistemaDto dto);
        Task <RegistroUsuarioSistemaViewModel> CreateAsync(RegistroUsuarioSistemaDto dto);
    }
}
