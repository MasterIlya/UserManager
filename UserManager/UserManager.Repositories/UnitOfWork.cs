using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IRepositoryContext _context;

        public UnitOfWork(IRepositoryContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {

            return _context.Set<TEntity>();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
