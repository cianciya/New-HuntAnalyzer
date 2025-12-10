using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Utilitarios.Jogador
{
    public class JogadorBalanceViewModel
    {
        public string? PlayerName { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
        public decimal ShouldPayOrReceive { get; set; }
    }
}
