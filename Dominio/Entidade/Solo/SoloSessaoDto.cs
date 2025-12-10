using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Sessao;

namespace Dominio.Entidade.Solo
{
    public class SoloSessaoDto : SessaoBaseDto
    {
        public int XpGain { get; set; }
        public int XpPerHour { get; set; }
        public int Damage { get; set; }
        public int DamagePerHour { get; set; }
        public int Healing { get; set; }
        public int HealingPerHour { get; set; }
    }
}
