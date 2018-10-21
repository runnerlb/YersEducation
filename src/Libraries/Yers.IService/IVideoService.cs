using Yers.DTO.Video;

namespace Yers.IService
{
    public interface IVideoService : IServiceSupport
    {
        long AddNew(VideoAddDto dto);

        void Update(VideoAddDto dto);

        VideoAddDto GetById(long id);

        VideoListDto[] GetAll();

        VideoListDto[] GetPagedData(string title, out int total, int page, int limit);

        void MarkDeleted(long id);
    }
}