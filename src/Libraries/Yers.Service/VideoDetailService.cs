using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Yers.DTO;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class VideoDetailService : IVideoDetailService
    {
        public long AddNew(VideoDetailAddDto dto)
        {
            VideoDetailEntity videoDetail = dto.EntityMap();
            videoDetail.CreateDateTime = DateTime.Now;
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoDetailEntity> bs
                    = new BaseService<VideoDetailEntity>(ctx);

                if (bs.GetAll().Any(m => m.VideoDetailName == videoDetail.VideoDetailName))
                {
                    throw new ArgumentException("该视频标题已存在，请检查");
                }

                ctx.VideoDetails.Add(videoDetail);

                ctx.SaveChanges();

                return videoDetail.Id;
            }
        }

        public VideoDetailAddDto GetById(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoDetailEntity> videoDetailService = new BaseService<VideoDetailEntity>(ctx);

                return videoDetailService.GetById(id).EntityMap();
            }
        }

        public VideoDetailListDto[] GetVideoDetailList(long videoId)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoDetailEntity> bs
                    = new BaseService<VideoDetailEntity>(ctx);

                var videlDetail = bs.GetAll().Where(m => m.VideoId == videoId).ToList();

                return videlDetail.Select(h => h.EntityMapToList()).ToArray();
            }
        }

        public void MarkDeleted(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoDetailEntity> bs
                    = new BaseService<VideoDetailEntity>(ctx);
                bs.MarkDeleted(id);
            }
        }

        public void Update(VideoDetailAddDto dto)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<VideoDetailEntity> bs
                    = new BaseService<VideoDetailEntity>(ctx);

                bool exists = bs.GetAll().Any(u => u.VideoDetailName == dto.VideoDetailName && u.Id != dto.Id);

                if (exists)
                {
                    throw new ArgumentException("该视频已经存在:" + dto.VideoDetailName);
                }
                var entity = dto.EntityMap();

                DbEntityEntry<VideoDetailEntity> entry = ctx.Entry<VideoDetailEntity>(entity);
                entry.State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}