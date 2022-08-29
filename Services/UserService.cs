using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Services.Abstract;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
		public UserService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext)
		{
		}

		public bool Login(UserDTO user)
        {
            return true;
        }
    }
}
