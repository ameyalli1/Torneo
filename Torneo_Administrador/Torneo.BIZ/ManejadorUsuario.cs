using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;

namespace Torneo.BIZ
{
    public class ManejadorUsuario : IManejadorUsuario
    {
        IRepositorio<Usuarios> repositorio;
        public ManejadorUsuario(IRepositorio<Usuarios> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Usuarios> Listar => repositorio.Read;

        public bool Agregar(Usuarios entidad)
        {
            return repositorio.Create(entidad);
        }

        public Usuarios BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Usuarios entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
