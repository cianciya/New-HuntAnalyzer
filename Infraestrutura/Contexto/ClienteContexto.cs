using Dominio.Entidade.Cacada;
using Dominio.Entidade.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Contexto
{
    public class ClienteContexto : DbContext
    {
        //DbSets para as entidades
        public DbSet<UsuarioSistema> UsuarioSistema { get; set; }
        public DbSet<Hunt> Hunt { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
