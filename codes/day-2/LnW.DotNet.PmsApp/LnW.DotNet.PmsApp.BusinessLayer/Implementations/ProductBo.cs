using LnW.DotNet.PmsApp.BusinessLayer.Abstractions;
using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;
using LnW.DotNet.PmsApp.Models;

namespace LnW.DotNet.PmsApp.BusinessLayer.Implementations
{
    public class ProductBo(IPmsDao<Product,string> _pmsDao) : IPmsBo<Product, string>
    {
        //private readonly IPmsDao<Product, string> _pmsDao;

        //public ProductBo(IPmsDao<Product, string> _pmsDao) => this._pmsDao = _pmsDao;

        public bool Add(Product data)
        {            
            return false;
        }

        public Product? Fetch(string id)
        {
            return null;
        }

        public IEnumerable<Product>? FetchAll(SortChoice sortChoice = SortChoice.SortById)
        {
            return null;
        }

        public bool Modify(string id, Product data)
        {
            return false;
        }

        public bool Remove(string id)
        {
            return false;
        }
    }
}
