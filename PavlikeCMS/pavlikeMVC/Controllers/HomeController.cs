using pavlikeLibrary;
using System.Web.Mvc;
using PavlikeDATA.Repos;

namespace pavlikeMVC.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";
            ViewBag.Albumler = new Albumler().GetAll();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}