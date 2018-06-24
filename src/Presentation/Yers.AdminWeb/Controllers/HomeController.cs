using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        public ISettingService SettingService { get; set; }

        public ActionResult Index()
        {
            //SettingService.Add("123", "123");
            return View();
        }

        public ActionResult Write()
        {
            Session["name"] = "张三";

            return Content("OK");
        }

        public ActionResult Read()
        {
            if (Session["name"] == null)
            {
                return Content("没有Session");
            }

            return Content((string)Session["name"]);
        }
    }
}