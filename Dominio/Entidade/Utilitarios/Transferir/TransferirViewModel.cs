using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Utilitarios.Transferir
{
    public class TransferirViewModel
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}
