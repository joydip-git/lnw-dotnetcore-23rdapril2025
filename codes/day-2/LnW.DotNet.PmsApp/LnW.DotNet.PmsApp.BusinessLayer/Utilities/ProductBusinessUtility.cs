using LnW.DotNet.PmsApp.Models;

namespace LnW.DotNet.PmsApp.BusinessLayer.Utilities
{
    internal static class ProductBusinessUtility
    {
        public static string AutoGenerateProductId(string lastId = "PRO-")
        {
            string finalId = lastId;
            if (lastId == "PRO-")
            {
                finalId += "0001";
            }
            else
            {
                string[] productIdParts = lastId.Split('-');
                string initialPart = productIdParts[0];
                string trailingPart = productIdParts[1];

                int trailingPartIdValue = int.Parse(trailingPart);
                string trailingIdString = (++trailingPartIdValue).ToString();
                string finalTrailingPart = trailingIdString.Length switch
                {
                    1 => "000" + trailingIdString,
                    2 => "00" + trailingIdString,
                    3 => "0" + trailingIdString,
                    4 => trailingIdString,
                    _ => trailingIdString
                };
                finalId = $"{initialPart}-{finalTrailingPart}";
            }
            return finalId;
        }

        public static IEnumerable<Product> SortProducts(IEnumerable<Product> products, SortChoice sortChoice)
        {
            return sortChoice switch
            {
                SortChoice.SortById => products.OrderBy(p => p.Id),
                SortChoice.SortByName => products.OrderBy(p => p.Name),
                SortChoice.SortByPrice => products.OrderBy(p => p.Price),
                SortChoice.SortByMake => products.OrderBy(p => p.Make),
                SortChoice.SortByYear => products.OrderBy(p => p.Year),
                _ => products.OrderBy(p => p.Id)
            };

        }

        public static bool ValidateProduct(Product product)
        {
            return !(product == null || product.Name == null || product.Name == string.Empty || product.Make == null || product.Make == string.Empty);
        }

        public static bool ValidateProductId(string productId)
        {
            if (productId == null || productId == string.Empty)
                throw new ArgumentNullException($"{nameof(productId)} is either empty or null reference");
            else
                return true;
        }
    }
}
