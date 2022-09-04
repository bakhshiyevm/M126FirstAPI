using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Abstract;
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
        protected readonly IRepository<TEntity> _repo;


		protected BaseService(IMapper mapper,IRepository<TEntity> repo)
		{
			_mapper = mapper;
            _repo = repo;
		}

		public virtual IEnumerable<TRsDTO> Get()
        {

            var ent = _repo.Get();

            var dtos = _mapper.Map<IEnumerable<TRsDTO>>(ent);   

            return dtos;
        }


        public virtual TRsDTO Get(int id)
        {

            var ent = _repo.Get(id);

            var rsdto = _mapper.Map<TRsDTO>(ent);

            return rsdto;
        }

        public virtual TRsDTO Create(TRqDTO dto)
        {


            var ent = _mapper.Map<TEntity>(dto);


            _repo.Create(ent);
            
            var rsdto = _mapper.Map<TRsDTO>(ent);


            return rsdto;
        }

        public virtual void Update(TRqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);
 
              _repo.Update(ent);
        }

        public virtual int Delete(int id)
        {
            return _repo.Delete(id);

        }
    }
}
