using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Yers.DTO;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.FrontWeb.Controllers
{
    public class HomeController : Controller
    {
        public IIdNameService IdNamesService { get; set; }
        public IVideoService VideoService { get; set; }
        public IVideoDetailService VideoDetailService { get; set; }
        public ActionResult Sndex()
        {
            //获取轮播图
            var listShouYeLunBo = IdNamesService.GetByTypeName("首页轮播图");
            ViewBag.ShouYeLunBo = listShouYeLunBo;

            //获取公告
            var listGongGao = IdNamesService.GetByTypeName("首页公告");
            ViewBag.ShouYeGongGao = listGongGao;

            //获取快速推荐
            var listTuiJian = IdNamesService.GetByTypeName("课程类型").Where(m => m.Remark == "快速推荐").ToList();
            ViewBag.ShouYeTuiJian = listTuiJian;

            //首页视频推荐
            var listVideoList = VideoService.GetAll().Take(10).ToList();
            ViewBag.ShouYeVideo = listVideoList;
            return View();
        }

        public ActionResult Index()
        {
            //获取轮播图
            var listShouYeLunBo = IdNamesService.GetByTypeName("首页轮播图");
            ViewBag.ShouYeLunBo = listShouYeLunBo;

            //获取公告
            var listGongGao = IdNamesService.GetByTypeName("首页公告");
            ViewBag.ShouYeGongGao = listGongGao;

            //首页分类
            var listCourseType = IdNamesService.GetByTypeName("家庭教育");
            ViewBag.ShouYeCourseType = listCourseType;

            //首页视频推荐
            var listVideoList = VideoService.GetAll().Take(10).ToList();
            ViewBag.ShouYeVideo = listVideoList;
            return View();
        }

        [HttpGet]
        public ActionResult GetList(int typeId = 0, int page = 1, int limit = 20)
        {
            List<VideoListDto> list = new List<VideoListDto>();
            //表示全部视频
            if (typeId == 0)
            {
                int total;
                list = VideoService.GetPagedData("", out total, page, limit).ToList();
            }
            else
            {

            }

            return Json(new AjaxResult { Data = list, Msg = "请求成功", Result = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult My()
        {
            return View();
        }

        public ActionResult Detail(int id,int detailId = 0)
        {
            var model = VideoService.GetById(id);
            model.VideoDetailListDtos = VideoDetailService.GetVideoDetailList(id).ToList();

            ViewBag.DetailId = detailId;
            return View(model);
        }
    }
}