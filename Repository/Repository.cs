using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Abstract;
using System;
using System.Linq;

namespace Repo
{
	public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : BaseEntity
	{

		protected AppDbContext _dbContext;
		protected DbSet<TEntity> _dbSet;

		public Repository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<TEntity>();
		}

		public TEntity Create(TEntity entity)
		{
			_dbSet.Add(entity);
			_dbContext.SaveChanges();
			return entity;
		}

		public int Delete(int id)
		{
			var ent = _dbSet.Find(id);	

			if (ent == null) 
			{
				throw new ArgumentNullException(nameof(ent));
			}
			_dbSet.Remove(ent);
			_dbContext.SaveChanges();
			return ent.Id;
		}

		public IQueryable<TEntity> Get()
		{		
			return _dbSet;
		}

		public TEntity Get(int id)
		{
			return _dbSet.Find(id);
		}

		public void Update(TEntity entity)
		{
			_dbSet.Update(entity);
			_dbContext.SaveChanges();
		}
	}
}
