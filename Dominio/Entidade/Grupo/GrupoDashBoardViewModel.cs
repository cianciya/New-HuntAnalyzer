using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Grupo
{
    public class GrupoDashBoardViewModel
    {
        public int Id { get; set; }
        public int HuntId { get; set; }
        public string? HuntName { get; set; }
        public int TotalBalance { get; set; }
        public int MembrosCount { get; set; }
        public string? Duracao { get; set; }
        public bool IsPaid { get; set; }
    }
}
