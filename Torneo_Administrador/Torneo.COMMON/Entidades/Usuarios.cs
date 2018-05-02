using System;
using System.Collections.Generic;
using System.Text;

namespace Torneo.COMMON.Entidades
{
   public  class Usuarios:Base
    {
        public string NombreUsuario { get; set; }
        public string Contraceña { get; set;  }
        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
