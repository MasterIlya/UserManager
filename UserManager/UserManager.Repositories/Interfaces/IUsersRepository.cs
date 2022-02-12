using System.Collections.Generic;
using UserManager.Repositories.Items;

namespace UserManager.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void Create(UserItem item);

        UserItem Get(int UserId);

        List<UserItem> Get(int skip, int take);

        UserItem GetByEmail(string email);

        void Update(UserItem item);

        void Remove(UserItem item);

        public int GetCount();
    }
}
