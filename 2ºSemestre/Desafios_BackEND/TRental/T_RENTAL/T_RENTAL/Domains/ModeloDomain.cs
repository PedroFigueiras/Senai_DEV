using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_RENTAL.Controllers
{
    public class ModeloDomain
    {
        public int IdModelo { get; set; }

        public int IdMarca { get; set; }

        public string modelo { get; set; }

        public MarcaDomain marca { get; set; }
    }
}
