using Yers.DTO.IdName;

namespace Yers.IService
{
    public interface IIdNameService : IServiceSupport
    {
        long AddNew(IdNameDto model);

        void Update(IdNameDto model);

        void MarkDeleted(long id);

        IdNameDto[] GetAll();

        IdNameDto GetById(long id);

        IdNameDto[] GetPagedData(string name, string typeName, out int total, int page = 1, int limit = 10);

        IdNameDto[] GetByTypeName(string typeName);

        void UpdateImage(int id, string fileName);
    }
}