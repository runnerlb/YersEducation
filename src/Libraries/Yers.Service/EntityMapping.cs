using AutoMapper;
using Yers.DTO;
using Yers.Service.Entities;

namespace Yers.Service
{
    public static class EntityMapping
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AdminUserDto, AdminUserEntity>();
                cfg.CreateMap<AdminUserEntity, AdminUserDto>();
                cfg.CreateMap<AdminUserAddDto, AdminUserEntity>();
            });
        }

        public static AdminUserEntity EntityMap(this AdminUserDto model)
        {
            return Mapper.Map<AdminUserEntity>(model);
        }

        public static AdminUserDto EntityMap(this AdminUserEntity model)
        {
            return Mapper.Map<AdminUserDto>(model);
        }

        public static AdminUserEntity EntityMap(this AdminUserAddDto model)
        {
            return Mapper.Map<AdminUserEntity>(model);
        }
    }
}