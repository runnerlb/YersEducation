using System.Web.Mvc;

namespace Yers.AdminWeb.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
    }
}