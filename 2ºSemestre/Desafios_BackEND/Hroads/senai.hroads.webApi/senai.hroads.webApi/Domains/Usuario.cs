using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Usuario
    {
        public short IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public virtual Tipousario IdTipoUsuarioNavigation { get; set; }
    }
}
