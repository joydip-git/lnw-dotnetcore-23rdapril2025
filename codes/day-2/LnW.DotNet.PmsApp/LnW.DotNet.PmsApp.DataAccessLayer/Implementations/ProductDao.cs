using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;
using LnW.DotNet.PmsApp.Models;


namespace LnW.DotNet.PmsApp.DataAccessLayer.Implementations
{
    public class ProductDao : IPmsDao<Product, string>
    {
        public bool Delete(string id)
        {
            return false;
        }

        public Product? Get(string id)
        {
            return null;
        }

        public Product[]? GetAll()
        {
            return null;
        }

        public bool Insert(Product data)
        {
            return false;
        }

        public bool Update(string id, Product data)
        {
            return false;
        }
    }
}
