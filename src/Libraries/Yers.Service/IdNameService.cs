using AutoMapper;
using System;
using System.Linq;
using Yers.DTO;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    public class IdNameService : IIdNameService
    {
        public long AddNew(IdNameDto model)
        {
            IdNameEntity idNameEntity = model.EntityMap();
            idNameEntity.CreateDateTime = DateTime.Now;
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> bs
                    = new BaseService<IdNameEntity>(ctx);

                if (bs.GetAll().Any(m => m.TypeName == idNameEntity.TypeName && m.Name == idNameEntity.Name))
                {
                    throw new ArgumentException("该数据已存在，请检查");
                }

                ctx.IdNames.Add(idNameEntity);

                ctx.SaveChanges();

                return idNameEntity.Id;
            }
        }

        public IdNameDto[] GetAll()
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> bs
                    = new BaseService<IdNameEntity>(ctx);

                var list = bs.GetAll().ToArray();
                return Mapper.Map<IdNameEntity[], IdNameDto[]>(list);
            }
        }

        public IdNameDto GetById(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> idNameBaseService = new BaseService<IdNameEntity>(ctx);

                return idNameBaseService.GetById(id).EntityMap();
            }
        }

        public IdNameDto[] GetPagedData(string name, string typeName, out int total, int page = 1, int limit = 10)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> idNameBaseService = new BaseService<IdNameEntity>(ctx);
                var idNameDto = idNameBaseService.GetAll()
                    .Where(a => a.Name.Contains(name) && a.TypeName.Contains(typeName) && !a.IsDeleted);

                total = idNameDto.Count();

                var idNameList = idNameDto.OrderBy(a => a.CreateDateTime)
                    .Skip(limit * (page - 1)).Take(limit).ToList().Select(h => h.EntityMap()).ToArray();

                return idNameList;
            }
        }

        public IdNameDto[] GetByTypeName(string typeName)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> idNameBaseService = new BaseService<IdNameEntity>(ctx);
                var idNameList = idNameBaseService.GetAll()
                    .Where(a => a.TypeName == typeName && !a.IsDeleted)
                    .ToList().Select(h => h.EntityMap()).ToArray();

                return idNameList;
            }
        }

        public void MarkDeleted(long id)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> bs
                    = new BaseService<IdNameEntity>(ctx);
                bs.MarkDeleted(id);
            }
        }

        public void Update(IdNameDto dto)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> bs
                    = new BaseService<IdNameEntity>(ctx);

                bool exists = bs.GetAll().Any(m => m.TypeName == dto.TypeName && m.Name == dto.Name && m.Id != dto.Id); ;

                if (exists)
                {
                    throw new ArgumentException("该数据已存在，请检查");
                }

                var model = bs.GetById(dto.Id);

                model.Name = dto.Name;
                model.TypeName = dto.TypeName;
                model.ImageSrc = dto.ImageSrc;
                model.Remark = dto.Remark;

                ctx.SaveChanges();
            }
        }

        public void UpdateImage(int id, string fileName)
        {
            using (YersDbContext ctx = new YersDbContext())
            {
                BaseService<IdNameEntity> bs
                    = new BaseService<IdNameEntity>(ctx);

                var model = bs.GetById(id);

                model.ImageSrc = fileName;
                ctx.SaveChanges();
            }
        }
    }
}