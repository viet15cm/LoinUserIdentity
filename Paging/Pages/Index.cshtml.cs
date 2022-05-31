using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Paging.Models;
using Paging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductServices _productServices;

        private readonly ItemServices _itemServices;
        public List<Product> products { get; set; }
      
        public const int ITEMS_PER_PAGES = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int CurrentPage { get; set; }
        public int CountPage { get; set; }

        
        public IndexModel(ILogger<IndexModel> logger , ProductServices productServices , ItemServices itemServices)
        {
            _productServices = productServices;
            _itemServices = itemServices;
            _logger = logger;
        }

        public async Task OnGet()
        {
            
            int totalProduct = _productServices.GetProducts().Count;
            CountPage = (int)(Math.Ceiling((double)totalProduct / ITEMS_PER_PAGES));
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > CountPage)
            {
                CurrentPage = CountPage;
            }

            var ps = (from p in _productServices.GetProducts()
                      select p).Skip((CurrentPage - 1) * 10).Take(ITEMS_PER_PAGES).ToList();

            products = ps;

            var c = await _productServices.GetFindProductItem(6);
            Console.WriteLine(c.Count);
        }
    }
}
