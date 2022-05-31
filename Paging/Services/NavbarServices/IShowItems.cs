using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services.NavbarServices
{
    public interface IShowItems
    {
         List<NavbarItemSettings> GetItem();
    }


}


