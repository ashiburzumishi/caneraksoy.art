using Entities;
using Managers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace caneraksoy.com.Controllers
{
    public class PhotographController : Controller

    {

        [HttpGet]
        public ActionResult sended()
        {
            var photomanager = new PhotoManager();
            var issucced = photomanager.sended(out List<Photograph> list);
            if (issucced)
            {
                return View(list);
            }
            else
            {
                return RedirectToAction("Home", "allArts");
            }
        }

        [HttpPost]
        public JsonResult sended (string id)
        {
            return Json(1);
        }

        public ActionResult genrePhoto (Photograph photo)
        {
            var photomanager = new PhotoManager();
            var issucced = photomanager.photos(out List<Photograph> genrePhoto);
            if (issucced)
            {
                return View(genrePhoto);
            }
            else
            {
                return RedirectToAction("Photograph", "genrePhoto");
            }
        }

       
    }
}