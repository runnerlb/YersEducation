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
                cfg.CreateMap<AdminLogEntity, AdminLogDto>()
                    .ForMember(dest => dest.AdminUserName, conf => conf.MapFrom(src => src.AdminUser.UserName));
                cfg.CreateMap<VideoAddDto, VideoEntity>();
                cfg.CreateMap<VideoEntity, VideoAddDto>();
                cfg.CreateMap<VideoEntity, VideoListDto>();
                cfg.CreateMap<VideoDetailEntity, VideoDetailListDto>();
                cfg.CreateMap<VideoDetailListDto, VideoDetailEntity>();
                cfg.CreateMap<VideoDetailEntity, VideoDetailListDto>();
                cfg.CreateMap<VideoDetailEntity, VideoDetailAddDto>();
                cfg.CreateMap<VideoDetailAddDto, VideoDetailEntity>();
                //.ForMember(m => m.Video, n => n.Ignore())
                //.ForMember(dest => dest.VideoTypeName, conf => conf.MapFrom(m=>m.VideoType.Name))
                //.ForMember(dest => dest.CourseTypeName, conf => conf.MapFrom(m=>m.CourseType.Name));
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
        public static VideoEntity EntityMap(this VideoAddDto model)
        {
            return Mapper.Map<VideoEntity>(model);
        }
        public static VideoAddDto EntityMap(this VideoEntity model)
        {
            return Mapper.Map<VideoAddDto>(model);
        }

        public static VideoListDto EntityMapToList(this VideoEntity model)
        {
            return Mapper.Map<VideoListDto>(model);
        }
        public static VideoDetailEntity EntityMap(this VideoDetailAddDto model)
        {
            return Mapper.Map<VideoDetailEntity>(model);
        }
        public static VideoDetailAddDto EntityMap(this VideoDetailEntity model)
        {
            return Mapper.Map<VideoDetailAddDto>(model);
        }

        public static VideoDetailListDto EntityMapToList(this VideoDetailEntity model)
        {
            return Mapper.Map<VideoDetailListDto>(model);
        }
    }
}