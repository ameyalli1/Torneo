using System;
using System.Collections.Generic;
using System.Text;

namespace Torneo.COMMON.Entidades
{
  public  class Deporte:Base
    {
        public string deporte { get; set; }

        public override string ToString()
        {
            return deporte;
        }
    }
}
