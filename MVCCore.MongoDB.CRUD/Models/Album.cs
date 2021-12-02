using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Models
{
    public class Album
    {
        [BsonId]
        public ObjectId Id { get; set; }


        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }


        public List<Song> Songs { get; set; }


        //// to delete
        //public Artist Artist2 { get; set; }
    }
}
