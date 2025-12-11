using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Usuario;

namespace Dominio.Interface.Usuario
{
    public interface IUsuarioRepository : IRepositoryBase<UsuarioSistema>
    {
        Task<UsuarioSistema> GetByUserNameAsync(object nomeUsuario);
    }
}
