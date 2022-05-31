using Microsoft.EntityFrameworkCore;
using Paging.DbContextLayer;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services
{
    public class ItemServices
    {
        private readonly UserDbContext _userDbContext;

        public ItemServices(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<List<Item>> GetAll()
        {
            try
            {
                var items = await _userDbContext.items.ToListAsync();

                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                
            }
        }


    }
}
