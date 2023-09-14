using LoveChat.DataAccess.Common.Interfaces;
using LoveChat.DataAccess.ViewModels;
using LoveChat.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.DataAccess.Interfaces.Users
{
    public interface IUserRepository : IRepository<User, UserViewModel>, 
        IGetAll<UserViewModel>, ISearchable<UserViewModel>
    {
        public Task<User?> GetByPhoneAsync(String phone);
    }
}
