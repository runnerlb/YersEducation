using Yers.DTO.VIdeoDetail;

namespace Yers.IService
{
    public interface IVideoDetailService : IServiceSupport
    {
        VideoDetailListDto[] GetVideoDetailList(long videoId);

        long AddNew(VideoDetailAddDto dto);

        void Update(VideoDetailAddDto dto);

        VideoDetailAddDto GetById(long id);

        void MarkDeleted(long id);
    }
}