namespace LnW.DotNet.PmsApp.DataAccessLayer.Abstractions
{
    public interface IPmsDao<T, TId> where T : class
    {
        bool Insert(T data);
        bool Delete(TId id);
        bool Update(TId id, T data);
        T? Get(TId id);
        //IEnumerable<T>? GetAll();
        T[]? GetAll();
    }
    //public interface IProductDao : IPmsDao<Product, string>
    //{
    //    IEnumerable<Product> Search(string name);
    //}
}
