using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCore.MongoDB.CRUD.Models;
using MVCCore.MongoDB.CRUD.Models.ViewModel;
using MVCCore.MongoDB.CRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Controllers
{
    public class SongController : Controller
    {


        // se crea una interfaz DB 
        private IAlbumCollection db = new AlbumCollection();


        public IActionResult Index()
        {
            return View();
        }



        //---------------------------------------------------------------------------
        // GET: SongController/Create
        public ActionResult Create(string id)
        {
            SongViewModel songVM = new SongViewModel { AlbumId = id, Song = new Song() };
            return View(songVM);  // retorna la vista Create.cshtml
        }

        // POST: SongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = db.GetAlbumById(collection["AlbumId"]);

                if (album.Songs == null)
                    album.Songs = new List<Song>();

                album.Songs.Add(new Song
                {
                    Name = collection["Song.Name"],
                    Duration = int.Parse(collection["Song.Duration"])
                });

                db.UpdateAlbum(album);

                return RedirectToAction("Index","Album");  // Obtiene el nombre "Index" y lo redirecciona allí
            }
            catch
            {
                return View();
            }
        }
        //---------------------------------------------------------------------------


    }
}
