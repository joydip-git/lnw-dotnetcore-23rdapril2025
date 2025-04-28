namespace LnW.DotNet.PmsApp.Models
{
    public class Product
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; } = string.Empty;

        public required decimal Price { get; set; }

        public int Year { get; set; } = DateTime.Now.Year;

        public required string Make { get; set; }

        public override string ToString() =>
         $"[Id={Id},Name={Name},Price={Price},Make={Make},Description={Description},Year={Year}]";
    }
}
