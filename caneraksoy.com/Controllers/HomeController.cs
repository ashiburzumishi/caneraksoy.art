using Entities;
using Managers;
using System.Collections.Generic;
using System.Web.Mvc;

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

        public ActionResult allArts()
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