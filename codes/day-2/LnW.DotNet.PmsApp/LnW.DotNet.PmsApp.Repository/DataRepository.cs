using LnW.DotNet.PmsApp.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json;

namespace LnW.DotNet.PmsApp.Repository
{
    public static class DataRepository
    {
        private static ObservableCollection<Product> products = [];

        static DataRepository()
        {
            products.CollectionChanged += new NotifyCollectionChangedEventHandler(ProductsCollectionChanged);
        }

        private static void ProductsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var data = e.NewItems?[0] as Product;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    //var index = e.NewStartingIndex;
                    //Products[index];                   
                    AddDataInFile(data);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    DeleteDataFromFile(data);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    UpdateDataIntoFile(data);
                    break;

                default:
                    break;
            }
        }

        private async static void AddDataInFile(Product? p)
        {
            try
            {
                //if (p == null) throw new ArgumentNullException(nameof(p));
                using (FileStream stream = new(@"D:\training\lnw-dotnetcore-23rdapril2025\codes\day-2\LnW.DotNet.PmsApp\products.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await JsonSerializer.SerializeAsync<ObservableCollection<Product>>(stream, await Products(), new JsonSerializerOptions { WriteIndented = true });
                    stream.Flush();
                    //stream.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void DeleteDataFromFile(Product? p)
        {

        }

        private static void UpdateDataIntoFile(Product? p) { }

        //public static ObservableCollection<Product> Products { get; } = [
        //    new Product{ Id="PRO-0001", Name="Dell XPS", Make="Dell", Description="New laptop from Dell", Price=130000, Year=2019}];

        public async static Task<ObservableCollection<Product>?> Products()
        {
            try
            {
                using (FileStream stream = new(@"D:\training\lnw-dotnetcore-23rdapril2025\codes\day-2\LnW.DotNet.PmsApp\products.json", FileMode.Open, FileAccess.ReadWrite))
                {

                    products = await JsonSerializer.DeserializeAsync<ObservableCollection<Product>>(stream);
                    stream.Flush();
                    //stream.Close();
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
