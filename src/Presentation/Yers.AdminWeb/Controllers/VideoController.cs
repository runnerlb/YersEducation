using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Yers.Common;
using Yers.DTO;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.AdminWeb.Controllers
{
    public class VideoController : Controller
    {
        public IIdNameService IdNameService { get; set; }
        public IVideoService VideoService { get; set; }
        public IVideoDetailService VideoDetailService { get; set; }
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
            return Json(new AjaxResult { Result = true, Msg = "视频修改成功" });
        }

        [HttpGet]
        public ActionResult GetVideoTypeList(long id)
        {
            var model = IdNameService.GetById(id);

            var videoTypeList = IdNameService.GetByTypeName(model.Name).Select(m => new { text = m.Name, value = m.Id });

            return Json(new AjaxResult { Result = true, Data = videoTypeList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(long videoId)
        {
            var model = VideoService.GetById(videoId);
            ViewBag.VideoTitle = model.Title;
            var list = VideoDetailService.GetVideoDetailList(videoId).ToList();

            ViewBag.VideoId = videoId;
            return View(list);
        }

        [HttpGet]
        public ActionResult InfoEdit(long videoId, long videoDetailId = 0)
        {
            ViewBag.VideoId = videoId;
            VideoDetailAddDto dto = new VideoDetailAddDto();
            if (videoDetailId > 0)
            {
                dto = VideoDetailService.GetById(videoDetailId);
            }

            return View(dto);
        }

        [HttpPost]
        public ActionResult InfoEdit(VideoDetailAddDto dto)
        {
            if (dto.Id <= 0)
            {
                VideoDetailService.AddNew(dto);

                AdminLogService.AddNew($"添加课程信息:{dto.VideoDetailName}");
                return Json(new AjaxResult { Result = true, Msg = "课程添加成功" });
            }
            VideoDetailService.Update(dto);

            AdminLogService.AddNew($"修改课程信息:{dto.VideoDetailName}");
            return Json(new AjaxResult { Result = true, Msg = "课程修改成功" });
        }

        #region 分片上传文件
        [HttpPost]
        public ActionResult Upload()
        {
            string fileName = Request["name"];
            int index = Convert.ToInt32(Request["chunk"]);//当前分块序号
            var guid = Request["guid"];//前端传来的GUID号
            var dir = Server.MapPath("~/UploadImage");//文件上传目录
            dir = Path.Combine(dir, guid);//临时保存分块的目录
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            string filePath = Path.Combine(dir, index.ToString());//分块文件名为索引名，更严谨一些可以加上是否存在的判断，防止多线程时并发冲突
            var data = Request.Files["file"];//表单中取得分块文件
            //if (data != null)//为null可能是暂停的那一瞬间
            //{
            data.SaveAs(filePath);//报错
            //}
            return Json(new { erron = 0 });//Demo，随便返回了个值，请勿参考
        }
        public ActionResult Merge()
        {
            var guid = Request["guid"];//GUID
            var uploadDir = Server.MapPath("~/UploadImage");//Upload 文件夹
            var dir = Path.Combine(uploadDir, guid);//临时文件夹
            var fileName = Guid.NewGuid() + Request["fileName"];//文件名
            var files = System.IO.Directory.GetFiles(dir);//获得下面的所有文件
            var finalPath = Path.Combine(uploadDir, fileName);//最终的文件名（demo中保存的是它上传时候的文件名，实际操作肯定不能这样）
            var fs = new FileStream(finalPath, FileMode.Create);
            foreach (var part in files.OrderBy(x => x.Length).ThenBy(x => x))//排一下序，保证从0-N Write
            {
                var bytes = System.IO.File.ReadAllBytes(part);
                fs.Write(bytes, 0, bytes.Length);
                bytes = null;
                System.IO.File.Delete(part);//删除分块
            }
            fs.Flush();
            fs.Close();
            System.IO.Directory.Delete(dir);//删除文件夹
            return Json(new AjaxResult { Data = fileName, Msg = "上传成功", Result = true });//随便返回个值，实际中根据需要返回
        }
        #endregion
    }
}