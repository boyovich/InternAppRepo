using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Domain.Entities
{
    public class PaginationResponse<T>
    {
        public List<T> ResponseList { get; set; }
        public int Count { get; set; }

    }
}
