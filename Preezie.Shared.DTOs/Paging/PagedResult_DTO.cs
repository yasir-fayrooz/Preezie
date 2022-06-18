using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preezie.Shared.DTOs.Paging
{
    public class PagedResult_DTO<T>
    {
        public long TotalItems { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }
    }
}
