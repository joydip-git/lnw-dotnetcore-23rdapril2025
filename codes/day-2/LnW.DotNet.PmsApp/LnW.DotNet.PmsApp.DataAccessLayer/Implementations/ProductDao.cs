using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;
using LnW.DotNet.PmsApp.Models;
using static LnW.DotNet.PmsApp.Repository.DataRepository;


namespace LnW.DotNet.PmsApp.DataAccessLayer.Implementations
{
    public class ProductDao : IPmsDao<Product, string>
    {
        public bool Delete(string id)
        {
            try
            {
                if (Exists(id))
                {
                    var found = Find(id);
                    var done = Products.Remove(found);
                    return done;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product? Get(string id)
        {
            try
            {
                if (!Exists(id))
                    return null;
                else
                    return Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product[]? GetAll()
        {
            try
            {
                return Products.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(Product data)
        {
            try
            {
                Products.Add(data);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(string id, Product data)
        {
            try
            {
                if (!Exists(id))
                    return false;
                else
                {
                    Product found = Find(id);
                    found.Name = data.Name;
                    found.Description = data.Description;
                    found.Price = data.Price;
                    found.Make = data.Make;
                    found.Year = data.Year;                    

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Helper Methods
        private bool Exists(string id) => Products.Any(p => p.Id == id);

        private Product Find(string id) => Products.Where(p => p.Id == id).First();
        #endregion

    }
}
