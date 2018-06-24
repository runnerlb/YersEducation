using System;
using System.Linq;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class SettingService : ISettingService
    {
        public void Add(string key, string value)
        {
            using (YersDbContext db = new YersDbContext())
            {
                BaseService<SettingEntity> bs = new BaseService<SettingEntity>(db);

                if (db.Settings.Any(m => m.Name == key))
                {
                    throw new ArgumentException("参数名称已经存在");
                }

                SettingEntity model = new SettingEntity()
                {
                    Name = key,
                    Value = value
                };

                db.Settings.Add(model);

                db.SaveChanges();
            }
        }
    }
}