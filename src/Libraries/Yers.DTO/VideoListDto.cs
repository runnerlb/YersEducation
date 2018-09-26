using System;

namespace Yers.DTO
{
    public class VideoListDto: BaseDto
    {
        /// <summary>
        /// 视频封面图片
        /// </summary>
        public string CoverPicture { get; set; }

        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 讲师姓名
        /// </summary>
        public string LecturerName { get; set; }

        /// <summary>
        /// 讲师头像
        /// </summary>
        public string LecturerHead { get; set; }

        /// <summary>
        /// 优惠价格
        /// </summary>
        public decimal PreferentialPrice { get; set; }

        /// <summary>
        /// 视频摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 视频内容
        /// </summary>
        public string VideoContent { get; set; }
        /// <summary>
        /// 上线时间
        /// </summary>
        public string OnlineTime { get; set; }
        /// <summary>
        /// 课程类型Id
        /// </summary>
        public long CourseTypeId { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        public string CourseTypeName { get; set; }

        /// <summary>
        /// 视频类型Id
        /// </summary>
        public long VideoTypeId { get; set; }
        /// <summary>
        /// 视频类型
        /// </summary>
        public string VideoTypeName { get; set; }
    }
}