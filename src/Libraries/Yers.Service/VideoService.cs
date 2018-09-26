using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Yers.DTO;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class VideoService : IVideoService
    {
        public long AddNew(VideoAddDto dto)
        {
            VideoEntity videoEntity = dto.EntityMap();
            videoEntity.CreateDateTime = DateTime.Now;
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoEntity> bs
                    = new BaseService<VideoEntity>(ctx);

                if (bs.GetAll().Any(m => m.Title == videoEntity.Title))
                {
                    throw new ArgumentException("该视频标题已存在，请检查");
                }

                ctx.Videos.Add(videoEntity);

                ctx.SaveChanges();

                return videoEntity.Id;
            }
        }

        public VideoAddDto GetById(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoEntity> videoService = new BaseService<VideoEntity>(ctx);

                return videoService.GetById(id).EntityMap();
            }
        }

        public VideoListDto[] GetAll()
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoEntity> videoBaseService = new BaseService<VideoEntity>(ctx);
                var videoDto = videoBaseService.GetAll()
                    .Where(a=>!a.IsDeleted).ToList();

                return videoDto.Select(h => h.EntityMapToList()).ToArray();
            }
        }

        public VideoListDto[] GetPagedData(string title, out int total, int page, int limit)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoEntity> videoBaseService = new BaseService<VideoEntity>(ctx);
                var videoDto = videoBaseService.GetAll()
                    .Where(a => a.Title.Contains(title)  && !a.IsDeleted);

                total = videoDto.Count();

                var videoList = videoDto.OrderBy(a => a.CreateDateTime)
                    .Skip(limit * (page - 1)).Take(limit).ToList();

                return videoList.Select(h => h.EntityMapToList()).ToArray();
            }
        }

        public void MarkDeleted(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoEntity> bs
                    = new BaseService<VideoEntity>(ctx);
                bs.MarkDeleted(id);
            }
        }

        public void Update(VideoAddDto dto)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoEntity> bs
                    = new BaseService<VideoEntity>(ctx);

                bool exists = bs.GetAll().Any(u => u.Title == dto.Title && u.Id != dto.Id);

                if (exists)
                {
                    throw new ArgumentException("该视频已经存在:" + dto.Title);
                }
                var entity = dto.EntityMap();

                DbEntityEntry<VideoEntity> entry = ctx.Entry<VideoEntity>(entity);
                entry.State = EntityState.Modified;
                ctx.SaveChanges();

                //ctx.Videos.Attach(entity);
                //ctx.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);

                //ctx.SaveChanges();
            }
        }
    }
}