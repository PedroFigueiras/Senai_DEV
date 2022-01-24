using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_RENTAL.Controllers
{
    public class AluguelDomain
    {
        public int IdAluguel { get; set; }

        public int IdVeiculo { get; set; }

        public int IdCliente { get; set; }

        public DateTime Aluguel { get; set; }

        public DateTime Devolucao { get; set; }

        public VeiculoDomain veiculo { get; set; }

        public ClienteDomain cliente { get; set; }

    }
}
