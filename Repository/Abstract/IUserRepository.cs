using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Abstract
{
	public interface IUserRepository : IRepository<User>
	{
		public bool Login(User entity);
	}
}
