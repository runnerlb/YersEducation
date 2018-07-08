using System;
using Yers.DTO;

namespace Yers.IService
{
    public interface IAdminLogService : IServiceSupport
    {
        long AddNew(string message);

        AdminLogDto[] GetPagedData(string message, string ip, DateTime? begin, DateTime? end, int adminUserId, out int total,
            int page = 1, int limit = 10);
    }
}