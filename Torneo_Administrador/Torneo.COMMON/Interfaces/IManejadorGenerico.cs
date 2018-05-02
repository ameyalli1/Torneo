using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Torneo.COMMON.Entidades;

namespace Torneo.COMMON.Interfaces
{
   public interface IManejadorGenerico<T>where T:Base
    {

        bool Agregar(T entidad);
        List<T> Listar { get; }
        bool Eliminar(ObjectId Id);
        bool Modificar(T entidad);
        T BuscarPorId(ObjectId Id);
    }
}
