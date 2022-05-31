using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services.NavbarServices
{
    public class NavbarItemSettings
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<ItemsChildren> itemsChildrens { get; set; }
    }
}
