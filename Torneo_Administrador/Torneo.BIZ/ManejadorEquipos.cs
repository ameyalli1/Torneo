using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;

namespace Torneo.BIZ
{
    public class ManejadorEquipos : IManejadorEquipo
    {

        IRepositorio<Equipos> repositorio;
        public ManejadorEquipos(IRepositorio<Equipos> repositorio)
        {
            this.repositorio = repositorio;
        }


        public List<Equipos> Listar => repositorio.Read;

        public bool Agregar(Equipos entidad)
        {
            return repositorio.Create(entidad);
        }




        /*public int Aleatorios(string palabra)
        {
            int valor = ContadorDeBuscarEquipo(palabra);
            Random a = new Random();
            int v = 0;
            return v = a.Next(1, valor);
        }*/



        public Equipos BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }


        public IEnumerable BuscarEquipos(string palabra)
        {
            return Listar.Where(e => e.Deporte== palabra).ToList();
        }



        public int ContadorDeBuscarEquipo(string palabra)
        {
            return Listar.Where(e => e.Deporte== palabra).ToList().Count();
        }

        public bool ContarNumeroTelefonico(string telefono)
        {

            //que me ayuden a contar los datos que no sea espacion es blanco
            int var = 0;
            for (int i = 0; i <= telefono.Count(); i++)
            {

                if (i != 32)
                {

                    var++;
                }
            }
            if (var == 10)
            {
                return true;
            }
            else
            {
                return false;
            }


            //que me ayuden a contar los datos que no sea espacion es blanco
        }



        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Equipos entidad)
        {
            return repositorio.Update(entidad);
        }
        public bool VerificarSiEsNumero(string telefono)
        {
            foreach (var item in telefono)
            {
                if (!(char.IsNumber(item)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public int Aleatorios(string palabra)
        {
            int valor = ContadorDeBuscarEquipo(palabra);
            Random a = new Random();
            int v = 0;
            return v = a.Next(1, valor);
        }
    }
}
