using DataAccess.Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public bool Login(User user)
        {
            return true;
        }
    }
}
