using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Yers.Common;
using Yers.DTO;
using Yers.FrameworkWeb;
using Yers.IService;

namespace Yers.FrontWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(HomeController));

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

        public ActionResult Index(int type = 1)
        {
            logger.Info(HttpContext.Request.Form.Count);

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

        public ActionResult Detail(int id, int detailId = 0)
        {
            var model = VideoService.GetById(id);
            model.VideoDetailListDtos = VideoDetailService.GetVideoDetailList(id).ToList();

            ViewBag.DetailId = detailId;
            return View(model);
        }


        /// <summary>
        /// 定义Token，与微信公共平台上的Token保持一致
        /// </summary>
        private const string Token = "YersEducation";

        /// <summary>
        /// 验证签名，检验是否是从微信服务器上发出的请求
        /// </summary>
        /// <param name="model">请求参数模型 Model</param>
        /// <returns>是否验证通过</returns>
        private bool CheckSignature(WeChatRequestDto model)
        {
            string signature, timestamp, nonce, tempStr;
            //获取请求来的参数
            signature = model.signature;
            timestamp = model.timestamp;
            nonce = model.nonce;
            //创建数组，将 Token, timestamp, nonce 三个参数加入数组
            string[] array = { Token, timestamp, nonce };
            //进行排序
            Array.Sort(array);
            //拼接为一个字符串
            tempStr = String.Join("", array);
            //对字符串进行 SHA1加密
            tempStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tempStr, "SHA1").ToLower();
            //判断signature 是否正确
            if (tempStr.Equals(signature))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Valid(WeChatRequestDto model)
        {
            //获取请求来的 echostr 参数
            string echoStr = model.echostr;
            //通过验证
            if (CheckSignature(model))
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    //将随机生成的 echostr 参数 原样输出
                    Response.Write(echoStr);
                    //截止输出流
                    Response.End();
                }
            }
        }

        /// <summary>
        /// 对页面是否要用授权 用snsapi_base方式 获取Code Appid是微信应用id
        /// </summary>
        /// <returns></returns>
        public string GetCodeUrl(string Appid = "wxdda289b7230abfe0", string redirect_uri = "https://c843733e.ngrok.io/Home/Index")
        {
            return string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect", Appid, redirect_uri);
        }

        /// <summary>
        /// 用Code换取Openid
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public string CodeGetOpenid(string Code)
        {
            //string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", Appid, Appsecret, Code);
            //string ReText = CommonHelper.WebRequestPostOrGet(url, "");//post/get方法获取信息 
            //Dictionary<string, object> DicText = (Dictionary<string, object>)JsonConvert.DeserializeObject(ReText);
            //if (!DicText.ContainsKey("openid"))
            //    return "";
            //return DicText["openid"].ToString();

            return null;
        }


        /// <summary>
        /// 用openid换取用户信息
        /// </summary>
        /// <param name="openid">微信标识id</param>
        /// <returns></returns>
        public Dictionary<string, object> GetUserInfo(string openid)
        {
            return null;
            //JavaScriptSerializer Jss = new JavaScriptSerializer();
            //string access_token = ApiCommon.getTokenSession(Appid, Appsecret);//获取access_token
            //string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", access_token, openid);
            //Dictionary<string, object> respDic = (Dictionary<string, object>)Jss.DeserializeObject(WebRequestPostOrGet(url, ""));
            //return respDic;
        }
    }
}