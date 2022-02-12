using Microsoft.EntityFrameworkCore;

namespace UserManager.Repositories
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>()
            where T : class;

        int SaveChanges();
    }
}
