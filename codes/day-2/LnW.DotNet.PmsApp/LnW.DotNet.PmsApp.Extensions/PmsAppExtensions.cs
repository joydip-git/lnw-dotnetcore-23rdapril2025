using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;

namespace LnW.DotNet.PmsApp.Extensions
{
    public static class PmsAppExtensions
    {
        public static T[]? Search<T, TId, TSearchElement>(this IPmsDao<T, TId> dao, TSearchElement searchElement) where T : class
        {
            //var records = dao.GetAll();
            //records.AsQueryable<T>()
            return [];
        }
    }
}
