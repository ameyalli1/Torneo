using System;
using System.Collections.Generic;
using System.Text;
using Torneo.COMMON.Entidades;

namespace Torneo.COMMON.PuntosGrafica
{
  public  class Generadora
    {
        public Generadora()
        {
            Puntos = new List<Puntos>();
        }

        public List<Puntos> Puntos { get; set; }

        public List<Puntos> GeneradorDatos(List<TorneoLista> listatorneo, double limiteInferior, double limiteSuperior, double incremento)
        {
            Puntos = new List<Puntos>();
            double contador = 1;
            foreach (var item in listatorneo)
            {
                Puntos.Add(new Puntos(contador++, item.Puntaje));
            }
            return Puntos;
        }
    }
}
