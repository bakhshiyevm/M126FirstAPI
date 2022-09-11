using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DTO;
using Services.Abstract;
using Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
		public UserService(IMapper mapper, AppDbContext dbContext) : base(mapper, dbContext)
		{
		}

		public override UserDTO Create(UserDTO dto)
        {
            var res = _dbContext.Users.Where(x => x.Username == dto.Username);
            if (res.Count() > 0) 
            {
                throw new Exception("User exists!");
            }
            dto.Salt = Crypto.GenerateSalt();

			dto.PasswordHash = Crypto.GenerateBase64Hash(dto.Password,dto.Salt);

			return base.Create(dto);
		}

        public UserDTO Login(UserDTO dto)
        {

            var res = _dbContext.Users.Where(x => x.Username.ToLower() == dto.Username.ToLower());

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();

                var hash = Crypto.GenerateBase64Hash(dto.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var model = _mapper.Map<User, UserDTO>(res.First());                   

                    return model;
                }
                else
                {
                    throw new Exception("Wrong password!");
                }
            }
            else
            {
                throw new Exception("User not found");
            }

        }
    }
}
