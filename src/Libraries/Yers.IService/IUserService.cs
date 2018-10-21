using Yers.DTO.User;

namespace Yers.IService
{
    public interface IUserService : IServiceSupport
    {
        long AddNew(UserAddDto dto);

        void Update(UserAddDto dto);

        UserDto GetById(long id);

        UserDto[] GetAll();

        UserDto[] GetPagedData(string title, out int total, int page, int limit);

        void MarkDeleted(long id);

        bool Exist(string openId);

        UserDto GetByOpenId(string openId);
    }
}