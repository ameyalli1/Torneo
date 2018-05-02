using System;
using System.Collections.Generic;
using System.Text;

namespace Torneo.COMMON.PuntosGrafica
{
  public  class Puntos
    {
        public double X { get; set; }

        public double Y { get; set; }
        public Puntos(double x, double y)
        {
            X = x;
            Y = y;; 

        }
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
