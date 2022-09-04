using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Abstract
{
	public interface IRepository<TEntity>
	{
		IQueryable<TEntity> Get();
		TEntity Get(int id);
		TEntity Create(TEntity entity);
		void Update(TEntity entity);
		int Delete(int id);
	}
}
