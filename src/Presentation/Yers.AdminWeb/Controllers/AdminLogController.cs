using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class AdminLogController : Controller
    {
        public IAdminLogService AdminLogService { get; set; }
        public IAdminUserService AdminUserService { get; set; }

        // GET: Log
        [HttpGet]
        public ActionResult Index()
        {
            var adminList = AdminUserService.GetAll().Select(m => new { value = m.Id, label = m.UserName }).ToList();
            adminList.Insert(0, new { value = (long)0, label = "请选择操作人" });
            ViewBag.AdminUserJsonList = JsonConvert.SerializeObject(adminList);
            return View(adminList);
        }

        [HttpGet]
        public ActionResult GetList(string message, string ip, int adminUserId, DateTime? begin, DateTime? end, int page = 1,
            int limit = 10)
        {
            int total;
            var list = AdminLogService.GetPagedData(message, ip, begin, end, adminUserId, out total, page, limit);

            return Json(new AjaxResult { Result = true, Data = new { Data = list, Total = total } }, JsonRequestBehavior.AllowGet);
        }
    }
}