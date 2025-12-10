using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Cacada;
using Dominio.Entidade.Sessao;

namespace Dominio.Entidade.Solo
{
    public class SoloSessao : SessaoBase
    {
        public int HuntId { get; set; }
        public Hunt? Hunt { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Duration { get; set; } = string.Empty;

        public int XpGain { get; set; }
        public int XpHour { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
        public int Damage { get; set; }
        public int DamageHour { get; set; }
        public int Healing { get; set; }
        public int HealingHour { get; set; }

        // Futuro (opcional)
        public string? KilledMonsters { get; set; }
        public string? LootedItems { get; set; }
    }
}
