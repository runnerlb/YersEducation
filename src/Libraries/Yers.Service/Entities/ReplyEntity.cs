namespace Yers.Service.Entities
{
    /// <summary>
    /// 评论回复信息
    /// </summary>
    public class ReplyEntity : BaseEntity
    {
        /// <summary>
        /// 视频Id
        /// </summary>
        public long? VideoId { get; set; }

        /// <summary>
        /// 视频信息
        /// </summary>
        public virtual VideoEntity Video { get; set; }

        /// <summary>
        /// 书籍Id
        /// </summary>
        public long? BookId { get; set; }

        /// <summary>
        /// 书籍信息
        /// </summary>
        public virtual BookEntity Book { get; set; }

        /// <summary>
        /// 评论Id
        /// </summary>
        public long CommentId { get; set; }

        /// <summary>
        /// 评论信息
        /// </summary>
        public virtual CommentEntity Comment { get; set; }

        /// <summary>
        /// 回复信息
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 回复人Id
        /// </summary>
        public long FromUserId { get; set; }

        /// <summary>
        /// 回复人信息
        /// </summary>
        public virtual UserEntity FromUser { get; set; }

        /// <summary>
        /// 目标用户Id
        /// </summary>
        public long ToUserId { get; set; }

        /// <summary>
        /// 目标用户信息
        /// </summary>
        public virtual UserEntity ToUser { get; set; }
    }
}