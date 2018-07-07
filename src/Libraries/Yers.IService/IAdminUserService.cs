using Yers.DTO;

namespace Yers.IService
{
    public interface IAdminUserService : IServiceSupport
    {
        long AddNew(AdminUserAddDto model);

        void Update(AdminUserAddDto model);

        void MarkDeleted(long id);

        AdminUserDto[] GetAll();

        AdminUserDto GetById(long id);

        AdminUserDto[] GetPagedData(string userName, string loginName, string phone, string email, out int total, int page = 1, int limit = 10);

        AdminUserDto Login(string loginName, string loginPwd);
    }
}