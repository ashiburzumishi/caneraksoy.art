using System.Web.Mvc;
using Entities;
using Managers;
using System.Collections.Generic;

namespace caneraksoy.com.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var photomanager = new PhotoManager();
            var issucced = photomanager.photos(out List<Photograph> photo);
            if (issucced)
            {
                return View(photo);
            }
            else
            {
                return RedirectToAction("Home", "Index");
            }
        }

        public ActionResult allArts ()
        {
            var photomanager = new PhotoManager();
            var issucced = photomanager.photos(out List<Photograph> photo);
            if (issucced)
            {
                return View(photo);
            }
            else
            {
                return RedirectToAction("Home", "allArts");
            }
        }
    }
}