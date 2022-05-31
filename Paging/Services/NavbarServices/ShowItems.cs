using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services.NavbarServices
{
    public class ShowItems : IShowItems
    {
        private readonly List<NavbarItemSettings> navbarItemSettings;
        public ShowItems(IOptions<List<NavbarItemSettings>> options)
        {
           
            navbarItemSettings = options.Value;
            
        }
        public List<NavbarItemSettings> GetItem()
        {
            return navbarItemSettings;
        }
    }
}
