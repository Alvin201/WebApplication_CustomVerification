using System.Web.Mvc;
using WebApplication_CustomVerification.Verification;

namespace WebApplication_CustomVerification.Controllers
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

        [CustomAuthorize(ListId = 1111)]
        public ActionResult List_01()
        {

            return View();
        }

        [CustomAuthorize(ListId = 1112)]
        public ActionResult List_02()
        {

            return View();
        }

        [CustomAuthorize(ListId = 1113)]
        public ActionResult List_03()
        {

            return View();
        }
    }
}