namespace LnW.DotNet.PmsApp.Models
{
    public class Product
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; } = string.Empty;

        public required decimal Price { get; set; }

        public int Year { get; set; } = DateTime.Now.Year;

        public required string Make { get; set; }
    }
}
