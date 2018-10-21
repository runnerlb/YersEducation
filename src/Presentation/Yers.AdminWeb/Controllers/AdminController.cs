using System.Web.Mvc;
using Yers.DTO.AdminUser;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class AdminController : Controller
    {
        public IAdminUserService AdminUserService { get; set; }
        public IAdminLogService AdminLogService { get; set; }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList(string userName, string loginName, string phone, string email, int page = 1, int limit = 10)
        {
            int total;
            var list = AdminUserService.GetPagedData(userName, loginName, phone, email, out total, page, limit);

            return Json(new AjaxResult { Result = true, Data = new { Data = list, Total = total } }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(AdminUserAddDto adminUser)
        {
            if (adminUser.Id <= 0)
            {
                AdminUserService.AddNew(adminUser);
                AdminLogService.AddNew($"添加管理员:{adminUser.LoginName}");
                return Json(new AjaxResult { Result = true, Msg = "管理员添加成功" });
            }
            AdminUserService.Update(adminUser);

            AdminLogService.AddNew($"修改管理员【LoginName:{adminUser.LoginName}，Id:{adminUser.Id}】");
            return Json(new AjaxResult { Result = true, Msg = "管理员修改成功" });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dto = AdminUserService.GetById(id);
            AdminUserService.MarkDeleted(id);

            AdminLogService.AddNew($"删除管理员【LoginName:{dto.LoginName}，UserName：{dto.UserName}，Id:{dto.Id}】");
            return Json(new AjaxResult { Result = true, Msg = "删除成功" });
        }
    }
}