using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Models.ViewModel
{
    public class SongViewModel
    {
        public Song Song { get; set; }
        public string AlbumId { get; set; }
    }
}
