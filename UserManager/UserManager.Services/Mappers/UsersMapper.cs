using System;
using System.Collections.Generic;
using UserManager.Repositories.Items;
using UserManager.Services.Models;
using UserManager.Commons.Enums;

namespace UserManager.Services.Mappers
{
    public class UsersMapper
    {
        public static UserItem Map(RegistrationUserModel model)
        {
            if(model == null)
            {
                return null;
            }

            return new UserItem
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
                RegistrationDate = DateTime.Now,
                LoginDate = DateTime.Now,
                State = StateTypes.UNBLOCKED
            };
        }

        public static UserModel Map(UserItem item)
        {
            if(item == null)
            {
                return null;
            }

            return new UserModel
            {
                UserId = item.UserId,
                Email = item.Email,
                Password = item.Password,
                Name = item.Name,
                RegistrationDate = item.RegistrationDate,
                LoginDate = item.LoginDate,
                State = item.State,
                Delisted = item.Delisted
            };
        }

        public static PaginationUserModel  Map(List<UserModel> generalUserModels, int countOfPages, int currentPage)
        {
            return new PaginationUserModel
            {
                UserModels = generalUserModels,
                CountOfPages = countOfPages,
                CurrentPage = currentPage
            };
        }
    }
}
