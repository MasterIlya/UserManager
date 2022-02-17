using System.Collections.Generic;
using System.Linq;
using UserManager.Repositories.Interfaces;
using UserManager.Repositories.Items;

namespace UserManager.Repositories.Repositories
{
    public class UsersRepository : BaseRepository<UserItem>, IUsersRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<UserItem> Get(int skip, int take)
        {
            return GetItems()
                .Where(x => !x.Delisted)
                .OrderBy(x => x.UserId)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<UserItem> Get()
        {
            return GetItems()
                .Where(x => !x.Delisted)
                .OrderBy(x => x.UserId)
                .ToList();
        }

        public UserItem GetByEmail(string email)
        {
            return GetItems().FirstOrDefault(x => x.Email == email.Trim().ToLower() && !x.Delisted);
        }

        public int GetCount()
        {
            return GetItems().Where(x => !x.Delisted).Count();
        }
    }
}
