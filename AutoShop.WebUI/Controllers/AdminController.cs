using System.Web.Mvc;

namespace AutoShop.WebUI.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}