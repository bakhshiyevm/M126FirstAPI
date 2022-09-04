using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Repo.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
        private IUserRepository _userRepo;
		public UserService(IMapper mapper, IRepository<User> repo, IUserRepository userRepo) : base(mapper, repo)
		{
		}

		public bool Login(UserDTO user)
        {
            var ent = _mapper.Map<User>(user);
            return _userRepo.Login(ent);
            
        }
    }
}
