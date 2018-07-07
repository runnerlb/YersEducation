using log4net;
using System;
using System.Web.Mvc;
using Yers.DTO;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class AdminController : Controller
    {
        public IAdminUserService AdminUserService { get; set; }
        private static ILog _log = LogManager.GetLogger(typeof(AdminController));

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList(string userName, string loginName, string phone, string email, int page = 1, int limit = 10)
        {
            try
            {
                int total;
                var list = AdminUserService.GetPagedData(userName, loginName, phone, email, out total, page, limit);

                return Json(new AjaxResult { Result = true, Data = new { Data = list, Total = total } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                _log.Error("分页获取管理员", e);
                return Json(new AjaxResult() { Result = false, Msg = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Add(AdminUserAddDto adminUser)
        {
            if (adminUser.Id <= 0)
            {
                AdminUserService.AddNew(adminUser);

                return Json(new AjaxResult { Result = true, Msg = "管理员添加成功" });
            }
            else
            {
                AdminUserService.Update(adminUser);

                return Json(new AjaxResult { Result = true, Msg = "管理员修改成功" });
            }
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AdminUserService.MarkDeleted(id);

            return Json(new AjaxResult { Result = true, Msg = "删除成功" });
        }
    }
}