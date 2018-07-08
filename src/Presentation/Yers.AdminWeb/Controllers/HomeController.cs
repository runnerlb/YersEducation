using System.Web.Mvc;
using Yers.Common;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        public ISettingService SettingService { get; set; }
        public IAdminUserService AdminUserService { get; set; }
        public IAdminLogService AdminLogService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        #region 管理员登录

        [SkipCheckLogin]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [SkipCheckLogin]
        public ActionResult Login(string loginName, string loginPwd)
        {
            var dto = AdminUserService.Login(loginName, loginPwd);
            if (dto.Id <= 0)
            {
                return Json(new AjaxResult { Result = false, Msg = "账号或密码错误" });
            }

            Session[Keys.AdminUserName] = dto.UserName;
            Session[Keys.AdminId] = dto.Id;

            AdminLogService.AddNew("登录系统");
            return Json(new AjaxResult { Result = true, Msg = "登录成功" });
        }

        #endregion 管理员登录

        #region 退出登录

        public ActionResult Logout()
        {
            AdminLogService.AddNew("退出登录");
            Session.Clear();

            return RedirectToAction("Login");
        }

        #endregion 退出登录
    }
}