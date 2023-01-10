using AnishSqlWebApp.Models;
using AnishSqlWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnishSqlWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public async void OnGet()
        {
            //ProductService productService = new ProductService();
            // Products = _productService.GetProducts();
            Products = _productService.GetProducts().GetAwaiter().GetResult();

        }
    }
}