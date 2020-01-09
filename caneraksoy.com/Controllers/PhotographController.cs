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
        public ActionResult Addphotograph(Photographs photographs)
        {
            
        }
    }
}