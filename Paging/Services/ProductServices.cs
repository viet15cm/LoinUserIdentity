using Microsoft.EntityFrameworkCore;
using Paging.DbContextLayer;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services
{
    public class ProductServices
    {
        private readonly UserDbContext _userDbContext;

        public ProductServices(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        private List<Product> products { get; set; }

        public List<Product> GetProducts()
        {
            try
            {
                products = _userDbContext.products.ToList();

                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public async Task<List<Product>> GetFindProductItem(int Id)
        {
            try
            {
                var products = await (from p in _userDbContext.products
                                      where p.ItemId == Id
                                      select p).ToListAsync();
                return products;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return null;
        }

    }
}
