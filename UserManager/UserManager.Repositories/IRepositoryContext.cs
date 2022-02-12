using Microsoft.EntityFrameworkCore;

namespace UserManager.Repositories
{
    public interface IRepositoryContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        int SaveChanges();
    }
}
