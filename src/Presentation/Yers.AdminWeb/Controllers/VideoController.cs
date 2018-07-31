using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yers.Common;
using Yers.DTO;
using Yers.FrameworkWeb;
using Yers.IService;
using Yers.Service;
using Yers.Service.Entities;

namespace Yers.AdminWeb.Controllers
{
    public class VideoController : Controller
    {
        public IIdNameService IdNameService { get; set; }
        public IVideoService VideoService { get; set; }
        public IAdminLogService AdminLogService { get; set; }

        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList(string title, int page = 1, int limit = 10)
        {
            int total;
            var list = VideoService.GetPagedData(title, out total, page, limit);

            return Json(new AjaxResult { Result = true, Data = new { Data = list, Total = total } }, JsonRequestBehavior.AllowGet);
        }

        // TODO：没有删除对应的子项
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var video = VideoService.GetById(id);
            VideoService.MarkDeleted(id);

            AdminLogService.AddNew($"删除视频信息:{video.Title}");
            return Json(new AjaxResult { Result = true, Msg = "删除成功" });
        }

        [HttpGet]
        public ActionResult Edit(long id = 0)
        {
            var courseTypeList = IdNameService.GetByTypeName("课程类型").Select(m => new { text = m.Name, value = m.Id });
            ViewBag.CourseTypeList = JsonConvert.SerializeObject(courseTypeList);

            var videoTypeList = new List<IdNameDto>().Select(m => new { text = m.Name, value = m.Id });
            ViewBag.VideoTypeList = JsonConvert.SerializeObject(videoTypeList);
            VideoAddDto model;
            if (id <= 0)
                model = new VideoAddDto();
            else
                model = VideoService.GetById(id);
            ViewBag.Model = JsonConvert.SerializeObject(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VideoAddDto dto)
        {
            if (dto.Id <= 0)
            {
                dto.AdminUserId = long.Parse(Session[Keys.AdminId].ToString());
                VideoService.AddNew(dto);

                AdminLogService.AddNew($"添加视频信息:{dto.Title}");
                return Json(new AjaxResult { Result = true, Msg = "视频添加成功" });
            }
            VideoService.Update(dto);

            AdminLogService.AddNew($"修改视频信息:{dto.Title}");
            return Json(new AjaxResult { Result = true, Msg = "视频添加修改成功" });
        }

        [HttpGet]
        public ActionResult GetVideoTypeList(long id)
        {
            var model = IdNameService.GetById(id);

            var videoTypeList = IdNameService.GetByTypeName(model.Name).Select(m => new { text = m.Name, value = m.Id });

            return Json(new AjaxResult { Result = true, Data = videoTypeList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VideoDetail(long videoId)
        {

            return View();
        }
    }
}