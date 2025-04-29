using System.Drawing;

namespace EventHandlingDemo
{
    public class TextBox : Control
    {
        public string? Text { get; set; }
        public event ControlEventHandler? TextChanged;
        public void OnTextChanged() => TextChanged?.Invoke(
            this,
            new ControlEventArgs { EventArgs = this.Text }
            );
    }
}
