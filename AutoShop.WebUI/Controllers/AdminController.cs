
using System.Web.Mvc;
using AutoShop.WebUI.Security;

namespace AutoShop.WebUI.Controllers
{
    [Authorize2]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}