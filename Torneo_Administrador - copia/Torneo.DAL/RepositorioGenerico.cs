using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;

namespace Torneo.DAL
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : Base
    {
        private MongoClient client;
        private IMongoDatabase db;

        public RepositorioGenerico()
        {
            client = new MongoClient(new MongoUrl("mongodb://dany:dany123@ds111050.mlab.com:11050/ameyalli"));
            db = client.GetDatabase("ameyalli");
        }

        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Read => Collection().AsQueryable().ToList();

        public bool Create(T entidad)
        {
            try
            {
                Collection().InsertOne(entidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Delete(ObjectId id)
        {
            try
            {
                return Collection().DeleteOne(p => p.Id == id).DeletedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entidadModificada)
        {
            try
            {
            return    Collection().ReplaceOne(p => p.Id == entidadModificada.Id, entidadModificada).MatchedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
