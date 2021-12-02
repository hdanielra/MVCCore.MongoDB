using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;


        public MongoDBRepository()
        {
            // conexión mongo DB
            client = new MongoClient("mongodb://localhost:27017/");// mongodb://127.0.0.1:27017/

            // si no encuentra la BD la crea
            db = client.GetDatabase("MusicCatalog");
        }

    }
}
