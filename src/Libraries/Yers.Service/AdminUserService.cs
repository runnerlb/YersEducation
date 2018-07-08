using AutoMapper;
using System;
using System.Linq;
using Yers.Common;
using Yers.DTO;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class AdminUserService : IAdminUserService
    {
        public long AddNew(AdminUserAddDto model)
        {
            AdminUserEntity adminUser = model.EntityMap();

            string pwdHash = "123456".CalcMd5();
            adminUser.PasswordHash = pwdHash;
            adminUser.CreateDateTime = DateTime.Now;

            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);
                ctx.AdminUsers.Add(adminUser);

                bool exists = bs.GetAll().Any(u => u.LoginName == model.LoginName);

                if (exists)
                {
                    throw new ArgumentException("登录名已经存在" + model.LoginName);
                }

                ctx.AdminUsers.Add(adminUser);
                ctx.SaveChanges();
                return adminUser.Id;
            }
        }

        public void Update(AdminUserAddDto dto)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);

                bool exists = bs.GetAll().Any(u => u.LoginName == dto.LoginName && u.Id != dto.Id);

                if (exists)
                {
                    throw new ArgumentException("登录名已经存在" + dto.LoginName);
                }

                var model = bs.GetById(dto.Id);

                model.LoginName = dto.LoginName;
                model.UserName = dto.UserName;
                model.Email = dto.Email;
                model.PhoneNumber = dto.PhoneNumber;

                ctx.SaveChanges();
            }
        }

        public void MarkDeleted(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);
                bs.MarkDeleted(id);
            }
        }

        public AdminUserDto[] GetAll()
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> bs
                    = new BaseService<AdminUserEntity>(ctx);

                var list = bs.GetAll().ToArray();
                return Mapper.Map<AdminUserEntity[], AdminUserDto[]>(list);
            }
        }

        public AdminUserDto GetById(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> adminBaseService = new BaseService<AdminUserEntity>(ctx);

                return adminBaseService.GetById(id).EntityMap();
            }
        }

        public AdminUserDto[] GetPagedData(string userName, string loginName, string phone, string email, out int total, int page = 1,
            int limit = 10)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> adminBaseService = new BaseService<AdminUserEntity>(ctx);
                var adminDto = adminBaseService.GetAll()
                    .Where(a => a.UserName.Contains(userName) && a.LoginName.Contains(loginName) && a.Email.Contains(email) && a.PhoneNumber.Contains(phone) && !a.IsDeleted);

                total = adminDto.Count();

                var adminList = adminDto.OrderBy(a => a.CreateDateTime)
                     .Skip(limit * (page - 1)).Take(limit).ToList().Select(h => h.EntityMap()).ToArray();

                return adminList;
            }
        }

        public AdminUserDto Login(string loginName, string loginPwd)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminUserEntity> adminBaseService = new BaseService<AdminUserEntity>(ctx);

                var password = loginPwd.CalcMd5();

                if (!adminBaseService.GetAll()
                    .Any(m => m.LoginName == loginName && m.PasswordHash == password && !m.IsDeleted))
                {
                    return new AdminUserDto();
                }

                return adminBaseService.GetAll()
                    .FirstOrDefault(m => m.LoginName == loginName && m.PasswordHash == password && !m.IsDeleted)
                    .EntityMap();
            }
        }
    }
}