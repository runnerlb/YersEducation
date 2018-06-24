using System.Collections.Generic;

namespace Yers.Service.Entities
{
    public class PermissionEntity : BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}