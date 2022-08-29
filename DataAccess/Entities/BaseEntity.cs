using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }

		public DateTime CreatedAt { get; set; }
		public int CreatedUser { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int UpdatedUser { get; set; }
	}
}
