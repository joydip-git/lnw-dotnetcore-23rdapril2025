using LnW.DotNet.PmsApp.Models;
using System.Collections.Immutable;

namespace LnW.DotNet.PmsApp.BusinessLayer.Abstractions
{
    public interface IPmsBo<T, TId> where T : class
    {
        Task<bool> Add(T data);
        Task<bool> Remove(TId id);
        Task<bool> Modify(TId id, T data);
        Task<T?> Fetch(TId id);
        //IEnumerable<T>? FetchAll(SortChoice sortChoice = SortChoice.SortById);
        Task<ImmutableArray<Product>?> FetchAll(SortChoice sortChoice = SortChoice.SortById);
    }
}
