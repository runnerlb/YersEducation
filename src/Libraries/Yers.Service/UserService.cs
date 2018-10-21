using AutoMapper;
using System;
using System.Linq;
using Yers.DTO.User;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class UserService : IUserService
    {
        public long AddNew(UserAddDto dto)
        {
            UserEntity user = dto.EntityMap();

            var model = GetByOpenId(dto.AccountNumber);

            user.CreateDateTime = DateTime.Now;
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<UserEntity> bs
                    = new BaseService<UserEntity>(ctx);
                if (model == null || model.Id <= 0)
                {
                    ctx.Users.Add(user);
                }
                else
                {
                    var updateModel = bs.GetById(model.Id);
                    updateModel.UserName = user.UserName;
                    updateModel.HeadPortraitSrc = user.HeadPortraitSrc;
                    updateModel.AccountNumber = user.AccountNumber;
                    updateModel.LastLoginDateTime = DateTime.Now;
                    updateModel.Sex = user.Sex;
                }

                ctx.SaveChanges();

                return user.Id;
            }
        }

        public bool Exist(string openId)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<UserEntity> bs
                    = new BaseService<UserEntity>(ctx);

                return bs.GetAll().Any(m => m.AccountNumber == openId);
            }
        }

        public UserDto[] GetAll()
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<UserEntity> bs
                    = new BaseService<UserEntity>(ctx);

                var list = bs.GetAll().ToArray();
                return Mapper.Map<UserEntity[], UserDto[]>(list);
            }
        }

        public UserDto GetById(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<UserEntity> baseService = new BaseService<UserEntity>(ctx);

                return baseService.GetById(id).EntityMap();
            }
        }

        public UserDto GetByOpenId(string openId)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<UserEntity> baseService = new BaseService<UserEntity>(ctx);

                var model = baseService.GetAll().FirstOrDefault(m => m.AccountNumber == openId);
                model = model ?? new UserEntity();
                return model.EntityMap();
            }
        }

        public UserDto[] GetPagedData(string title, out int total, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public void MarkDeleted(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<UserEntity> bs
                    = new BaseService<UserEntity>(ctx);
                bs.MarkDeleted(id);
            }
        }

        public void Update(UserAddDto dto)
        {
            throw new NotImplementedException();
        }
    }
}