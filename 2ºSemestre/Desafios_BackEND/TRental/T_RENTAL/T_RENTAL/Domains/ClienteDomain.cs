using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_RENTAL.Controllers
{
    public class ClienteDomain
    {
        public int IdCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobrenomeCliente { get; set; }

        public string cnpjCliente { get; set; }

        public EmpresaDomain empresa { get; set; }

        public ModeloDomain modelo { get; set; }
    }
}
