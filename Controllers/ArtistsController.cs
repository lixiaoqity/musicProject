using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment6.Models;

namespace Assignment6.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.ArtistGetByIdWithMediaInfo(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();

            form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(form);
        }

        // POST: Artists/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newItem)
        {
            //Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // GET: Artists/i/AddAlbum
        [Route("artists/{id}/addalbum")]
        [Authorize(Roles = "Coordinator")]
        public ActionResult AddAlbum(int? id)
        {
            var o = m.ArtistGetByIdWithAlbums(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddFormViewModel();

                form.ArtistId = o.Id;
                form.ArtistName = o.Name;
                form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

                return View(form);
            }
        }


        // POST: Artists/i/AddAlbum
        [Route("artists/{id}/addalbum")]
        [Authorize(Roles = "Coordinator")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddFormViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", "Albums", new { id = addedItem.Id });
            }
        }

        // GET: Artists/i/AddArtistMediaItem
        [Route("artists/{id}/addartistmediaitem")]
        [Authorize(Roles = "Executive")]
        public ActionResult AddArtistMediaItem(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var a = m.ArtistGetById(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new ArtistMediaItemAddFormViewModel();
                form.ArtistId = a.Id;
                form.ArtistName = a.Name;
                return View(form);
            }
        }

        // POST: Artists/i/AddArtistMediaItem
        [Route("artists/{id}/addartistmediaitem")]
        [Authorize(Roles = "Executive")]
        [HttpPost]
        public ActionResult AddArtistMediaItem(int? id, ArtistMediaItemAddViewModel newItem)
        {
            if (!ModelState.IsValid || (id.GetValueOrDefault() != newItem.ArtistId))
            {
                return View(newItem);
            }

            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }

        }
    }
}
