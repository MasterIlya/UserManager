using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UserManager.Repositories
{
    public class BaseRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T Get(int id)
        {
            return DbSet().Find(id);
        }

        public void Create(T item)
        {

            DbSet().Add(item);
            _unitOfWork.SaveChanges();
        }

        public void Remove(T item)
        {
            DbSet().Remove(item);
            _unitOfWork.SaveChanges();
        }

        public void Update(T item)
        {
            DbSet().Update(item);
            _unitOfWork.SaveChanges();
        }

        protected IQueryable<T> GetItems()
        {
            return DbSet().AsQueryable();
        }
        private DbSet<T> DbSet()
        {
            return _unitOfWork.Set<T>();
        }

    }
}
