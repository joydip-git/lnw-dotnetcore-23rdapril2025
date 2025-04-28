using LnW.DotNet.PmsApp.BusinessLayer.Abstractions;
using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;
using LnW.DotNet.PmsApp.Models;
using System.Collections.Immutable;
using static LnW.DotNet.PmsApp.BusinessLayer.Utilities.ProductBusinessUtility;

namespace LnW.DotNet.PmsApp.BusinessLayer.Implementations
{
    public class ProductBo(IPmsDao<Product, string> _pmsDao) : IPmsBo<Product, string>
    {
        //private readonly IPmsDao<Product, string> _pmsDao;

        //public ProductBo(IPmsDao<Product, string> _pmsDao) => this._pmsDao = _pmsDao;

        public bool Add(Product data)
        {
            try
            {
                if (ValidateProduct(data))
                {
                    string? lastId = FetchAll()?.Last().Id;

                    if (lastId != null)
                    {
                        data.Id = AutoGenerateProductId(lastId);
                    }
                    else
                        data.Id = AutoGenerateProductId();
                    return _pmsDao.Insert(data);
                }
                else
                    throw new InvalidOperationException($"check {nameof(Product)} object..it is either null reference or one or more data is missing");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product? Fetch(string id)
        {
            try
            {
                Product? p = null;
                if (ValidateProductId(id))
                {
                    p = _pmsDao.Get(id);
                }
                if (p == null)
                    throw new Exception($"no {nameof(Product)} found with given {nameof(id)}");
                else
                    return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public IEnumerable<Product>? FetchAll(SortChoice sortChoice = SortChoice.SortById)
        //{
        //    return null;
        //}
        public ImmutableArray<Product>? FetchAll(SortChoice sortChoice = SortChoice.SortById)
        {
            try
            {
                var products = _pmsDao.GetAll();
                if (products?.Length > 0)
                {
                    return SortProducts(products, sortChoice).ToImmutableArray();
                }
                else
                    throw new Exception("no records found...");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(string id, Product data)
        {
            try
            {
                return ValidateProductId(id) && ValidateProduct(data) && _pmsDao.Update(id, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(string id)
        {
            try
            {
                return ValidateProductId(id) && _pmsDao.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
