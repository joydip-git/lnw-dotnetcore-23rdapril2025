using LnW.DotNet.PmsApp.Models;

namespace LnW.DotNet.PmsApp.Repository
{
    public static class Repository
    {
        public static IEnumerable<Product> Products { get; } = [
            new Product{ Id="PRO-0001", Name="Dell XPS", Make="Dell", Description="New laptop from Dell", Price=130000, Year=2019}];
    }
}
