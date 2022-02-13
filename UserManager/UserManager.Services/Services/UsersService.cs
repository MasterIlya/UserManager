using System;
using System.Linq;
using UserManager.Commons.Enums;
using UserManager.Repositories.Interfaces;
using UserManager.Services.IServices;
using UserManager.Services.Mappers;
using UserManager.Services.Models;

namespace UserManager.Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private const int DefaultUsersCount = 3;
        private const int DefaultCurrentPage = 1;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void CreateUser(RegistrationUserModel model)
        {
            var item = UsersMapper.Map(model);

            _usersRepository.Create(item);
        }

        public UserModel GetUserByEmail(string email)
        {
            var item = _usersRepository.GetByEmail(email);
            
            return UsersMapper.Map(item);
        }

        public UserModel GetUserById(int id)
        {
            var item = _usersRepository.Get(id);

            return UsersMapper.Map(item);
        }

        public PaginationUserModel GetUsers(int currentPage)
        {
            if (currentPage == 0)
            {
                currentPage = DefaultCurrentPage;
            }

            var skip = (currentPage - 1) * DefaultUsersCount;
            var take = DefaultUsersCount;

            var items = _usersRepository.Get(skip, take);

            var modelsList = items.Select(x => UsersMapper.Map(x)).ToList();

            var elementsCount = _usersRepository.GetCount();

            var countOfPages = Convert.ToInt32(Math.Ceiling((double)elementsCount / take));

            var result = UsersMapper.Map(modelsList, countOfPages, currentPage);

            return result;
        }

        public void UpdateLoginDate(AuthenticationUserModel model)
        {
            var item = _usersRepository.GetByEmail(model.Email);
            item.LoginDate = DateTime.Now;
            _usersRepository.Update(item);
        }

        public void BlockUsers(int[] ids)
        {
            foreach (var id in ids)
            {
                var item = _usersRepository.Get(id);
                item.State = StateTypes.BLOCKED;
                _usersRepository.Update(item);
            }

        }

        public void UnblockUsers(int[] ids)
        {
            foreach (var id in ids)
            {
                var item = _usersRepository.Get(id);
                item.State = StateTypes.UNBLOCKED;
                _usersRepository.Update(item);
            }
;
        }

        public void DeleteUsers(int[] ids)
        {
            foreach (var id in ids)
            {
                var item = _usersRepository.Get(id);
                _usersRepository.Remove(item);
            }

        }
    }
}
