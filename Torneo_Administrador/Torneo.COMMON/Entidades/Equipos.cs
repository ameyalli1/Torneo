using System;
using System.Collections.Generic;
using System.Text;

namespace Torneo.COMMON.Entidades
{
  public  class Equipos:Base
    {
        public string Nombre { get; set; }
        public string NumeroJugadores { get; set; }
      //  public List<NombreJupadores> { get; set; }
        public string Deporte { get; set; }
        //  public string PrecioCompra { get; set; }
        // public string Presentacion { get; set; }
        public override string ToString()
        {
            return Deporte;
        }

    }
}
