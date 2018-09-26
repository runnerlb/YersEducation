using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yers.DTO;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class IdNamesController : Controller
    {
        public IIdNameService IdNamesService { get; set; }
        public IAdminLogService AdminLogService { get; set; }

        // GET: Admin
        public ActionResult Index()
        {
            var list = IdNamesService.GetAll().GroupBy(m => m.TypeName).Select(m => new { text = m.Key, value = m.Key });
            ViewBag.TypeNameList = list;
            return View();
        }

        [HttpGet]
        public ActionResult GetList(string name, string typeName, int page = 1, int limit = 10)
        {
            int total;
            var list = IdNamesService.GetPagedData(name, typeName, out total, page, limit);

            return Json(new AjaxResult { Result = true, Data = new { Data = list, Total = total } }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(IdNameDto idName)
        {
            if (idName.Id <= 0)
            {
                IdNamesService.AddNew(idName);

                AdminLogService.AddNew($"添加基础数据:{idName.Name}");
                return Json(new AjaxResult { Result = true, Msg = "添加成功" });
            }
            IdNamesService.Update(idName);

            AdminLogService.AddNew($"修改基础数据:{idName.Name}");
            return Json(new AjaxResult { Result = true, Msg = "修改成功" });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var idName = IdNamesService.GetById(id);
            IdNamesService.MarkDeleted(id);

            AdminLogService.AddNew($"删除基础数据:{idName.Name}");
            return Json(new AjaxResult { Result = true, Msg = "删除成功" });
        }

        [HttpPost]
        public ActionResult UploadImage(int id = 0)
        {
            HttpPostedFileBase file = Request.Files[0];

            string fileName = Guid.NewGuid() + file.FileName;
            string path = Server.MapPath("~/UploadImage/" + fileName);

            file.SaveAs(path);
            if (id > 0)
            {
                IdNamesService.UpdateImage(id, fileName);
            }
            AdminLogService.AddNew("上传图片，图片名称：" + fileName);
            return Json(new AjaxResult { Result = true, Msg = "上传成功", Data = fileName });
        }
    }
}