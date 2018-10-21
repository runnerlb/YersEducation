namespace Yers.DTO.User
{
    public class UserDto : BaseDto
    {
        // <summary>
        /// 微信昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string HeadPortraitSrc { get; set; }
    }
}