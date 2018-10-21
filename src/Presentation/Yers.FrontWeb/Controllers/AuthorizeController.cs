using log4net;
using System.Web.Mvc;
using Yers.WxApi.UserApi;

namespace Yers.FrontWeb.Controllers
{
    public class AuthorizeController : Controller
    {
        //获取授权
        private Oauth2 oauth = new Oauth2();

        private readonly ILog logger = LogManager.GetLogger(typeof(HomeController));
        private readonly string AppId = System.Configuration.ConfigurationManager.AppSettings["Appid"];
        private readonly string RedirectUri = System.Configuration.ConfigurationManager.AppSettings["RedirectUri"];
        private readonly string Appsecret = System.Configuration.ConfigurationManager.AppSettings["Appsecret"];

        // GET: Authorize
        public ActionResult Index(int type = 1)
        {
            Session["CourseType"] = type;
            string url = oauth.GetCodeUrl(AppId, RedirectUri , "snsapi_userinfo");
            ViewBag.Url = url;
            return View();
        }
    }
}