using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Cacada
{
    internal class HuntStatusViewModel
    {
        public int HuntId { get; set; }
        public string? HuntName { get; set; }
        public int MaxBalance { get; set; }
        public int MaxXp { get; set; } // Para solo
        public int MaxLoot { get; set; } // Para solo
    }
}
