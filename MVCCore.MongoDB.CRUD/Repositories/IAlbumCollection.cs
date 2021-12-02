using MVCCore.MongoDB.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Repositories
{
 public   interface IAlbumCollection
    {
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(string id);

        List<Album> GetAllAlbums();

        Album GetAlbumById(string id);

    }
}
