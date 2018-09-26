using System;
using System.Collections.Generic;

namespace Yers.DTO
{
    public class VideoAddDto : BaseDto
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
        /// 视频摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 讲师头像
        /// </summary>
        public string LecturerHead { get; set; }

        /// <summary>
        /// 讲师职位
        /// </summary>
        public string LecturerPosition { get; set; }

        /// <summary>
        /// 原始价格
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// 优惠价格
        /// </summary>
        public decimal PreferentialPrice { get; set; }

        /// <summary>
        /// 视频内容
        /// </summary>
        public string VideoContent { get; set; }

        /// <summary>
        /// 上线时间
        /// </summary>
        public DateTime OnlineTime { get; set; }

        /// <summary>
        /// 上传人Id
        /// </summary>
        public long AdminUserId { get; set; }

        /// <summary>
        /// 课程类型Id
        /// </summary>
        public long CourseTypeId { get; set; }

        /// <summary>
        /// 视频类型Id
        /// </summary>
        public long VideoTypeId { get; set; }

        public List<VideoDetailListDto> VideoDetailListDtos { get; set; } = new List<VideoDetailListDto>();
    }
}