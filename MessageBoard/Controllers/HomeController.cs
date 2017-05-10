using System.Web.Mvc;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        /*public ActionResult Contact(string name, string email, string website, string comment)*/
        /*instead of passing these 4 parameters, we can pass a model instead*/
        public ActionResult Contact(ContactModel model)
        {
            return View();
        }
    }
}