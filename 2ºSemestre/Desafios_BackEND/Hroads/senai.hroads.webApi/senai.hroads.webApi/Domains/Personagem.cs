using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public short IdPersonagem { get; set; }
        public short? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public string CapacidadeMax { get; set; }
        public string CapacidadeMana { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
