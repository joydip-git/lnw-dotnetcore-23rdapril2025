namespace LnW.DotNet.PmsApp.DataAccessLayer.Abstractions
{
    public interface IPmsDao<T, TId> where T : class
    {
        Task<bool> Insert(T data);
        Task<bool> Delete(TId id);
        Task<bool> Update(TId id, T data);
        Task<T?> Get(TId id);
        //IEnumerable<T>? GetAll();
        Task<T[]?> GetAll();
    }
    //public interface IProductDao : IPmsDao<Product, string>
    //{
    //    IEnumerable<Product> Search(string name);
    //}
}
