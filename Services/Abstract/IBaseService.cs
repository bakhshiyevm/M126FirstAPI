using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBaseService<TEntity>
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(int id);
        public void Create(TEntity user);
        public void Update(TEntity user);
        public void Delete(int id);
    }
}
