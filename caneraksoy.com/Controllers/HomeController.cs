using Entities;
using Managers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public JsonResult like()
        {
            var likes = new List<Photograph>();
            SqlCommand command = new SqlCommand("Select * From photographs");
            var datatable = SqlManager.SqlManager.GetDataTable(command);
            foreach (DataRow row in datatable.Rows)
            {
                likes.Add(new Photograph
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Like = int.Parse(!string.IsNullOrEmpty(row["likeCount"].ToString()) ? row["likeCount"].ToString() : "0"),
                }
                    );
            }
            //linq to objects
            //var resultObj = likes.Select(x => new { like = x.Like });
            //resultObj = from obj in likes //linq to entities
            //            where obj.Id > 0
            //            select new
            //            {
            //                like = obj.Like,
            //            };
            return Json(likes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult sendArt2()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendArt2(Photograph degerler)
        {
            SqlCommand sendArtCommand = new SqlCommand("addArt")
            {
                CommandType = CommandType.StoredProcedure
            };
            sendArtCommand.Parameters.AddWithValue("Name", degerler.Name);
            sendArtCommand.Parameters.AddWithValue("Detail", degerler.Detail);
            sendArtCommand.Parameters.AddWithValue("Link", degerler.Link);
            sendArtCommand.Parameters.AddWithValue("artOwner", degerler.artOwner);
            sendArtCommand.Parameters.AddWithValue("ownerMail", degerler.ownerMail);
            sendArtCommand.Parameters.AddWithValue("Category", degerler.Category);
            var datatable = SqlManager.SqlManager.GetDataTable(sendArtCommand);

            return Json("1");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult newheader()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult errorPage()
        {
            return View();
        }

        public ActionResult contactPage()
        {
            return View();
        }
    }
}