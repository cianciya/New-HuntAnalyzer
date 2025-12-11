using Dominio.Entidade.Usuario;

namespace Servico.Interface.Token
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioSistema usuario);
        int GetIdUsuarioLogado();
    }
}
