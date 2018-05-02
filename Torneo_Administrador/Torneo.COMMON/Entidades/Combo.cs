using System;
using System.Collections.Generic;
using System.Text;

namespace Torneo.COMMON.Entidades
{
    public class Combo
    {
        public string Deporte { get; set; }
        public override string ToString()
        {
            return Deporte;     
        }
    }
}
