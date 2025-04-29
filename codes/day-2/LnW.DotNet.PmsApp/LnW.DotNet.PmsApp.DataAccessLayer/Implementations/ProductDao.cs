using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;
using LnW.DotNet.PmsApp.Models;
using static LnW.DotNet.PmsApp.Repository.DataRepository;


namespace LnW.DotNet.PmsApp.DataAccessLayer.Implementations
{
    public class ProductDao : IPmsDao<Product, string>
    {
        public async Task<bool> Delete(string id)
        {
            try
            {
                if (await Exists(id))
                {
                    var found = await Find(id);
                    if (found != null)
                    {
                        var done = (await Products())?.Remove(found);

                        return done.Value;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product?> Get(string id)
        {
            try
            {
                if (!await Exists(id))
                    return null;
                else
                    return await Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product[]?> GetAll()
        {
            try
            {
                return (await Products())?.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Insert(Product data)
        {
            try
            {
                var records = await Products();
                records?.Add(data);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(string id, Product data)
        {
            try
            {
                if (!await Exists(id))
                    return false;
                else
                {
                    Product found = await Find(id);
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
        private static async Task<bool> Exists(string id) => (await Products()).Any(p => p.Id == id);

        private static async Task<Product> Find(string id) => (await Products()).Where(p => p.Id == id).First();
        #endregion

    }
}
