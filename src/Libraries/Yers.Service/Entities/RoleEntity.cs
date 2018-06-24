using System.Collections.Generic;

namespace Yers.Service.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<PermissionEntity> Permissions { get; set; } = new List<PermissionEntity>();
        public ICollection<AdminUserEntity> AdminUsers { get; set; } = new List<AdminUserEntity>();
    }
}