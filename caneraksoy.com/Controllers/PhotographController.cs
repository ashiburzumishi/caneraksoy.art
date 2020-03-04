using Entities;
using Managers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace caneraksoy.com.Controllers
{
    public class PhotographController : Controller

    {
        [HttpGet]
        public ActionResult Addphotograph()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addphotograph(Photograph photographs)
        {
            var photomanager = new PhotoManager();
            var isSucced = photomanager.addphoto(photographs.Name, photographs.Detail, photographs.Link, out Photograph newphoto);
            if (isSucced)
                return RedirectToAction("Addphotograph", "Photograph");
            else
                return View();
        }

        public ActionResult photoInfo(int id)
        {
            return View();
        }

        [httpget]
        public ActionResult sendArt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sendArt(Photograph art)
        {
            var artmanager = new PhotoManager();
            var isSucced = artmanager.addArt(art.Name, art.Detail, art.Link, art.artOwner, art.ownerMail, art.Category, out Photograph newart);
            if (isSucced)
            {
                return RedirectToAction("", "");
            }
            else
                return View();

        }


        public ActionResult archive()
        {
            var archivemanager = new PhotoManager();
            var isSucced = archivemanager.photos(out List<Photograph> archive);
            if (isSucced)
            {
                return View(archive);
            }
            else
            {
                return View();
            }

           
        }
    }
}