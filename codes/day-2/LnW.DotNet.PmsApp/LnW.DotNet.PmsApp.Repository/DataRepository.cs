using LnW.DotNet.PmsApp.Models;

namespace LnW.DotNet.PmsApp.Repository
{
    public static class DataRepository
    {
        public static List<Product> Products { get; } = [
            new Product{ Id="PRO-0001", Name="Dell XPS", Make="Dell", Description="New laptop from Dell", Price=130000, Year=2019}];
    }
}
