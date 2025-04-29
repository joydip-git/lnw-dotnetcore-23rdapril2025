using System.ComponentModel;

namespace LnW.DotNet.PmsApp.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string name = string.Empty;
        public required string Id { get; set; }

        public required string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string? Description { get; set; } = string.Empty;

        public required decimal Price { get; set; }

        public int Year { get; set; } = DateTime.Now.Year;

        public required string Make { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString() =>
         $"[Id={Id},Name={Name},Price={Price},Make={Make},Description={Description},Year={Year}]";
    }
}
