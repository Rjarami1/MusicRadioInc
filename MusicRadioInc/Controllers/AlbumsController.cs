using MusicRadioInc.Models;
using MusicRadioInc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicRadioInc.Controllers
{
    public class AlbumsController : Controller
    {

        private ApplicationDbContext _context;

        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Albums
        public ActionResult Index(string albumString, string songString, bool orderPlaced = false)
        {
            var albums = _context.Albums.ToList();
            var songs = _context.SongSets.ToList();

            if (!string.IsNullOrWhiteSpace(songString))
            {
                var filteredSongs = songs.Where(s => s.Name.IndexOf(songString, StringComparison.OrdinalIgnoreCase) >= 0);
                var idAlbums = filteredSongs.Select(o => o.SongSetAlbumId).ToList();

                albums = albums.Where(a => idAlbums.Contains(a.Id)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(albumString))
                albums = albums.Where(a => a.Name.IndexOf(albumString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            

            List<AlbumViewModel> albumList = new List<AlbumViewModel>();

            foreach(var album in albums)
            {
                albumList.Add(new AlbumViewModel()
                {
                    Album = album,
                    SongList = songs.Where(s => s.SongSetAlbumId == album.Id).ToList()
                });
            }

            ViewBag.OrderPlaced = orderPlaced;

            return View(albumList);
        }

        //GET: Albums/Purchase/1
        [Authorize]
        public ActionResult Purchase(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if(user == null)
                return new HttpUnauthorizedResult("Usuario No Registrado.");
            

            var client = _context.Clients.SingleOrDefault(c => c.ApplicationUserId == user.Id);

            if(client == null)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Usuario no tiene un cliente asignado para poder registrar la compra.");

            var album = _context.Albums.SingleOrDefault(a => a.Id == id);

            if(album == null)
            {
                return HttpNotFound();
            }

            var ViewModel = new AlbumPurchaseViewModel()
            {
                Album = album,
                Client = client,
                Songs = _context.SongSets.Where(s => s.SongSetAlbumId == id).ToList()

            };

            return View(ViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PurchaseConfirm(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
                return new HttpUnauthorizedResult("Usuario No Registrado.");


            var client = _context.Clients.SingleOrDefault(c => c.ApplicationUserId == user.Id);

            if (client == null)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Usuario no tiene un cliente asignado para poder registrar la compra.");

            var album = _context.Albums.SingleOrDefault(a => a.Id == id);

            if (album == null)
            {
                return HttpNotFound();
            }

            var purchaseDetail = new PurchaseDetail()
            {
                PurchaseAlbumId = id,
                PurchaseClientId = client.Id,
                Total = 0 // Me vine a dar cuenta muy tarde que, para que este total funcione, 
                          //los albums deben tener valor, cosa que no estaba en el esquema inicial. 
                          //Esta tienda regala albums ahora ;)
            };

            _context.PurchaseDetails.Add(purchaseDetail);
            _context.SaveChanges();

            return RedirectToAction("Index", "Albums", new { albumString = "", songString = "", orderPlaced = true});
        }
    }
}