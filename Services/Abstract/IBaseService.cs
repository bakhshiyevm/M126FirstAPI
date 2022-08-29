using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBaseService<TRqDTO, TEntity, TRsDTO>
    {
        public IEnumerable<TRsDTO> Get();
        public TRsDTO Get(int id);
        public TRsDTO Create(TRqDTO user);
        public void Update(TRqDTO user);
        public int Delete(int id);
    }
}
