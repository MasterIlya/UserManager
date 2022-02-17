using System.Collections.Generic;
using UserManager.Services.Models;

namespace UserManager.Services.IServices
{
    public interface IUsersService
    {
        public void CreateUser(RegistrationUserModel model);
        public UserModel GetUserByEmail(string email);
        public UserModel GetUserById(int id);
        public PaginationUserModel GetUsers(int currentPage);
        public void UpdateLoginDate(AuthenticationUserModel model);
        public void BlockUsers(int[] ids);
        public void UnblockUsers(int[] ids);
        public void DeleteUsers(int[] ids);
        public List<UserModel> GetAllUsers();
    }
}
