using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Yers.DTO.User;
using Yers.DTO.Video;
using Yers.FrameworkWeb;
using Yers.IService;
using Yers.WxApi;
using Yers.WxApi.UserApi;

namespace Yers.FrontWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(HomeController));
        private readonly string AppId = System.Configuration.ConfigurationManager.AppSettings["Appid"];
        private readonly string RedirectUri = System.Configuration.ConfigurationManager.AppSettings["RedirectUri"];
        private readonly string Appsecret = System.Configuration.ConfigurationManager.AppSettings["Appsecret"];

        //获取授权
        private Oauth2 oauth = new Oauth2();

        public IIdNameService IdNamesService { get; set; }
        public IVideoService VideoService { get; set; }
        public IVideoDetailService VideoDetailService { get; set; }
        public IUserService UserService { get; set; }

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
            try
            {
                int type = 1;
                if (Session["CourseType"] != null && Session["CourseType"].ToString() != "")
                {
                    type = int.Parse(Session["CourseType"].ToString());
                }
                logger.Info($"type={type}");
                var code = HttpContext.Request.QueryString["code"];
                var openId = Session["OpenId"].ToString();
                logger.Info($"openId={openId}");
                //没有授权，没有获取
                if (string.IsNullOrEmpty(openId) && string.IsNullOrEmpty(code))
                {
                    return Redirect("/Authorize/Index?type=" + type);
                }
                //有code，没有openid
                if (string.IsNullOrEmpty(openId) && !string.IsNullOrEmpty(code))
                {
                    //有了code之后，判断如果授权之后，获取用户信息
                    var content = oauth.GetUserInfo(AppId, Appsecret, code);
                    var wxUserInfo = JsonConvert.DeserializeObject<WxUserInfo>(content);
                    Session["OpenId"] = wxUserInfo.openid;
                    //判断该微信号有没有注册过
                    UserAddDto user = new UserAddDto
                    {
                        AccountNumber = wxUserInfo.openid,
                        HeadPortraitSrc = wxUserInfo.headimgurl,
                        RegisterDataTime = DateTime.Now,
                        UserName = wxUserInfo.nickname,
                        WxAddress = wxUserInfo.country + "/" + wxUserInfo.province + "/" + wxUserInfo.city,
                        Sex = wxUserInfo.sex == "1"
                    };
                    logger.Info("添加用户信息，" + content);
                    UserService.AddNew(user);
                }

                //获取轮播图
                var listShouYeLunBo = IdNamesService.GetByTypeName("首页轮播图");
                ViewBag.ShouYeLunBo = listShouYeLunBo;

                //获取公告
                var listGongGao = IdNamesService.GetByTypeName("首页公告");
                ViewBag.ShouYeGongGao = listGongGao;

                //首页分类
                var model = IdNamesService.GetById(type);
                var listCourseType = IdNamesService.GetByTypeName(model.Name);
                ViewBag.ShouYeCourseType = listCourseType;
                ViewBag.CourseTypeId = type;

                //var listVideoList = VideoService.GetAll().Where().Take(10).ToList();
                //ViewBag.ShouYeVideo = listVideoList;
                return View();
            }
            catch (Exception ex)
            {
                logger.Error("主页加载错误", ex);
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 获取视频列表
        /// </summary>
        /// <param name="courseTypeId">课程类型</param>
        /// <param name="videoTypeId">视频类型</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">页容量</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetList(int courseTypeId, int videoTypeId = 0, int page = 1, int limit = 20)
        {
            logger.Info($"进入了GetList,courseTypeId={courseTypeId},videoTypeId={videoTypeId},page={page},limit={limit}");
            List<VideoListDto> list = new List<VideoListDto>();
            //表示全部视频
            if (videoTypeId == 0)
            {
                int total;
                list = VideoService.GetPagedData("", out total, page, limit).Where(m => m.CourseTypeId == courseTypeId).ToList();
            }
            else
            {
                int total;
                list = VideoService.GetPagedData("", out total, page, limit).
                    Where(m => m.CourseTypeId == courseTypeId && m.VideoTypeId == videoTypeId).ToList();
            }

            logger.Info($"请求成功,courseTypeId={courseTypeId},videoTypeId={videoTypeId},page={page},limit={limit}");
            return Json(new AjaxResult { Data = list, Msg = "请求成功", Result = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult My()
        {
            //TODO:这里有可能报错
            var openId = Session["OpenId"].ToString();

            var model = UserService.GetByOpenId(openId);

            return View(model);
        }

        public ActionResult Detail(int id, int detailId = 0)
        {
            var model = VideoService.GetById(id);
            model.VideoDetailListDtos = VideoDetailService.GetVideoDetailList(id).ToList();

            ViewBag.DetailId = detailId;
            return View(model);
        }
    }
}