using System;
using System.Linq;
using System.Web;
using Yers.Common;
using Yers.DTO.AdminLog;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class AdminLogService : IAdminLogService
    {
        public long AddNew(string message)
        {
            AdminLogEntity adminLogEntity = new AdminLogEntity
            {
                CreateDateTime = DateTime.Now,
                OperIp = CommonHelper.GetHostAddress(),
                Message = message,
                AdminUserId = int.Parse(HttpContext.Current.Session[Keys.AdminId].ToString())
            };

            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminLogEntity> bs
                    = new BaseService<AdminLogEntity>(ctx);

                ctx.AdminLogs.Add(adminLogEntity);

                ctx.SaveChanges();

                return adminLogEntity.Id;
            }
        }

        public AdminLogDto[] GetPagedData(string message, string ip, DateTime? begin, DateTime? end, int adminUserId, out int total, int page = 1,
            int limit = 10)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<AdminLogEntity> adminLogBaseService = new BaseService<AdminLogEntity>(ctx);
                var adminLog = adminLogBaseService.GetAll()
                    .Where(a => a.Message.Contains(message) && a.OperIp.Contains(ip) && !a.IsDeleted);
                if (adminUserId > 0)
                    adminLog = adminLog.Where(m => m.AdminUserId == adminUserId);
                if (begin != null)
                    adminLog = adminLog.Where(m => m.CreateDateTime >= begin);
                if (end != null)
                    adminLog = adminLog.Where(m => m.CreateDateTime <= end);

                total = adminLog.Count();

                var adminLogList = adminLog.OrderByDescending(a => a.CreateDateTime)
                    .Skip(limit * (page - 1)).Take(limit).ToList().Select(h => h.EntityMap()).ToArray();

                return adminLogList;
            }
        }
    }
}