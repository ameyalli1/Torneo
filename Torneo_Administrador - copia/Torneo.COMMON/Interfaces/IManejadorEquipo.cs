using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Torneo.COMMON.Entidades;

namespace Torneo.COMMON.Interfaces
{
    public   interface IManejadorEquipo:IManejadorGenerico<Equipos>
    {
        bool ContarNumeroTelefonico(string telefono);
        bool VerificarSiEsNumero(string telefono);
        IEnumerable BuscarEquipos(string palabra);
        int ContadorDeBuscarEquipo(string palabra);

        int Aleatorios(string palabra);
    }
}
