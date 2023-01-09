using AnishSqlWebApp.Models;

namespace AnishSqlWebApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}