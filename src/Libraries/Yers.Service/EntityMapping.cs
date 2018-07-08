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
                cfg.CreateMap<IdNameEntity, IdNameDto>();
                cfg.CreateMap<IdNameDto, IdNameEntity>();
                cfg.CreateMap<AdminLogDto, AdminLogEntity>();
                cfg.CreateMap<AdminLogEntity, AdminLogDto>().ForMember(dest => dest.AdminUserName, conf => conf.MapFrom(src => src.AdminUser.UserName));
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

        public static IdNameDto EntityMap(this IdNameEntity model)
        {
            return Mapper.Map<IdNameDto>(model);
        }

        public static IdNameEntity EntityMap(this IdNameDto model)
        {
            return Mapper.Map<IdNameEntity>(model);
        }

        public static AdminLogDto EntityMap(this AdminLogEntity model)
        {
            return Mapper.Map<AdminLogDto>(model);
        }

        public static AdminLogEntity EntityMap(this AdminLogDto model)
        {
            return Mapper.Map<AdminLogEntity>(model);
        }
    }
}