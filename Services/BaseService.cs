using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<TEntity>
    {
        public IEnumerable<TEntity> Get()
        {

            return new List<TEntity>();
        }


        public TEntity Get(int id)
        {
            

            return default(TEntity);
        }

        public void Create(TEntity user)
        {

        }

        public void Update(TEntity user)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
