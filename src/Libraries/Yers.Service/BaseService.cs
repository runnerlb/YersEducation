using System.Linq;
using Yers.IService;
using Yers.Service.Entities;

namespace Yers.Service
{
    internal class BaseService<T> where T : BaseEntity
    {
        private readonly YersDbContext _db;

        public BaseService(YersDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// 获取所有没有软删除的数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Where(m => !m.IsDeleted);
        }

        /// <summary>
        /// 获取总数据条数
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<T> GetPagedData(int startIndex, int count)
        {
            return GetAll().OrderBy(m => m.CreateDateTime).Skip(startIndex).Take(count);
        }

        /// <summary>
        /// 通过Id获取数据，如果没有则返回空
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return GetAll().SingleOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// 将数据标记为删除
        /// </summary>
        /// <param name="id"></param>
        public void MarkDeleted(long id)
        {
            var data = GetById(id);
            data.IsDeleted = true;
            _db.SaveChanges();
        }
    }
}