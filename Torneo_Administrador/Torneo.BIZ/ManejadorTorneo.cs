using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;

namespace Torneo.BIZ
{
    public class ManejadorTorneo : IManejadorTorneo
    {


        IRepositorio<Torneos> repositorio;
        public ManejadorTorneo(IRepositorio<Torneos> repositorio)
        {
            this.repositorio = repositorio;
        }


        public List<Torneos> Listar => repositorio.Read;

        public bool Agregar(Torneos entidad)
        {
            return repositorio.Create(entidad);
        }

        public Torneos BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Torneos entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
