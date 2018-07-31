namespace Yers.Service.Entities
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class IdNameEntity : BaseEntity
    {
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Remark { get; set; }
    }
}