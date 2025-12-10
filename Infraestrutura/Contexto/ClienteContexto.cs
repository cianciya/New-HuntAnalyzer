using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Contexto
{
    public class ClienteContexto : DbContext
    {
        //DbSets para as entidades



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
