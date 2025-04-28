using LnW.DotNet.PmsApp.DataAccessLayer.Abstractions;

namespace LnW.DotNet.PmsApp.Extensions
{
    public static class PmsAppExtensions
    {
        public static T[]? SearchByName<T, TId>(this IPmsDao<T, TId> dao, string name) where T : class
        {
            //var records = dao.GetAll();
            //records.AsQueryable<T>()
            return [];
        }
    }
}
