using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.PagingModels
{
    public class UserPaging
    {
        public int CurrentPages { get; set; }
        public int CountPages { get; set; }

        public Func<int?, string> GenegateUrl { get; set; }
    }
}
