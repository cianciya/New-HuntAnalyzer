using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Solo
{
    public class SoloDashboardViewModel
    {
        public int Id { get; set; }
        public int HuntId { get; set; }
        public string? HuntName { get; set; }

        public int Balance { get; set; }
        public int XpGain { get; set; }

        public string? Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool IsPaid { get; set; }
    }
}
