using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Tipohabilidade
    {
        public Tipohabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public short IdTipo { get; set; }
        public string DescricaoTipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
