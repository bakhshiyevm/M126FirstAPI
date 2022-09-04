using DataAccess;
using DataAccess.Entities;
using Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
	public class UserRepository : Repository<User>,IUserRepository 
	{

		public UserRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
		public bool Login(User entity)
		{
			var xq = _dbContext.Users.Where(x => x.Username == entity.Username);

			IEnumerable<User> xe = _dbContext.Users.Where(x => x.Username == entity.Username);
			return true;
		}

	}
}
