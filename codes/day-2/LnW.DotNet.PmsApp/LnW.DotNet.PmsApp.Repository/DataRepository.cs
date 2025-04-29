using LnW.DotNet.PmsApp.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json;

namespace LnW.DotNet.PmsApp.Repository
{
    public static class DataRepository
    {
        static DataRepository()
        {
            Products.CollectionChanged += new NotifyCollectionChangedEventHandler(ProductsCollectionChanged);
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

        private static void AddDataInFile(Product? p) { }
        private static void DeleteDataFromFile(Product? p) { }
        private static void UpdateDataIntoFile(Product? p) { }

        public static ObservableCollection<Product> Products { get; } = [
            new Product{ Id="PRO-0001", Name="Dell XPS", Make="Dell", Description="New laptop from Dell", Price=130000, Year=2019}];

    }
}
