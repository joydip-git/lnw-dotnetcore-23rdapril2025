using LnW.DotNet.PmsApp.Models;

namespace LnW.DotNet.PmsApp.BusinessLayer.Abstractions
{
    public interface IPmsBo<T, TId> where T : class
    {
        bool Add(T data);
        bool Remove(TId id);
        bool Modify(TId id, T data);
        T? Fetch(TId id);
        IEnumerable<T>? FetchAll(SortChoice sortChoice = SortChoice.SortById);
    }
}
