using MongoDB.Bson;
using MongoDB.Driver;
using MVCCore.MongoDB.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public class AlbumCollection : IAlbumCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();

        private IMongoCollection<Album> Collection;

        public AlbumCollection()
        {
            // una coleccion es equivalente a una tabla
            // si no existe la colección, se crea automáticamente
            Collection = _repository.db.GetCollection<Album>("Albums");
        }

        public void DeleteAlbum(string id)
        {
            var filter = Builders<Album>
                .Filter.Eq(s => s.Id, new ObjectId(id));

            // elimine cuando se cumpla el filtro
            Collection.DeleteOneAsync(filter);
        }

        public Album GetAlbumById(string id)
        {

            // en la BD el nombre del campo Id es _id

            var album = Collection.Find(
                new BsonDocument { { "_id", new ObjectId(id) } }
                ).FirstAsync().Result;

            return album;
        }

        public List<Album> GetAllAlbums()
        {
            var query = Collection
                .Find(new BsonDocument()).ToListAsync();

            return query.Result;
        }

        public void InsertAlbum(Album album)
        {
            //album.Artist2 = new Artist { Name = "Prueba Objeto", Country = "Turkia" };
            Collection.InsertOneAsync(album);
        }

        public void UpdateAlbum(Album album)
        {
            // construir un filtro para la coleccion album
            // teniendo el cuenta que el objeto de la bd sea igual al id del objeto como parámetro
            // reemplace el documento de la coleccion en la BD por el objeto que le paso como parámetro 


            var filter = Builders<Album>
                .Filter
                .Eq(s => s.Id, album.Id);

            // reemplace cuando se cumpla el filtro
            Collection.ReplaceOneAsync(filter, album);

        }
    }
}
