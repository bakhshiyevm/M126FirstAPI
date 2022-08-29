using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class BaseService<TRqDTO, TEntity, TRsDTO> 
        : IBaseService<TRqDTO, TEntity, TRsDTO> where TEntity : BaseEntity
    {

        protected readonly IMapper _mapper;

        protected readonly AppDbContext _dbContext;

        protected readonly DbSet<TEntity> _dbSet;

		protected BaseService(IMapper mapper, AppDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}

		public virtual IEnumerable<TRsDTO> Get()
        {
            var ent = _dbSet.ToList();

            var dtos = _mapper.Map<IEnumerable<TRsDTO>>(ent);   

            return dtos;
        }


        public virtual TRsDTO Get(int id)
        {
            var ent = _dbSet.Find(id);

            var rsdto = _mapper.Map<TRsDTO>(ent);

            return rsdto;
        }

        public virtual TRsDTO Create(TRqDTO dto)
        {


            var ent = _mapper.Map<TEntity>(dto);

            ent.CreatedAt = DateTime.Now;

            _dbSet.Add(ent);
            _dbContext.SaveChanges();

            var rsdto = _mapper.Map<TRsDTO>(ent);


            return rsdto;
        }

        public virtual void Update(TRqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);
 
            ent.UpdatedAt = DateTime.Now;
            _dbSet.Update(ent);

            _dbContext.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            var ent = _dbSet.Find(id);
            _dbSet.Remove(ent);
            _dbContext.SaveChanges();
            return ent.Id;

        }
    }
}
