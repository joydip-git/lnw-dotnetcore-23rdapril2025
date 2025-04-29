// See https://aka.ms/new-console-template for more information
using EventHandlingDemo;

Console.WriteLine("Hello, World!");

Form form = new();
if (form.Controls[0] != null && form.Controls[0] is TextBox)
{
    var textBox = form.Controls[0] as TextBox;
    textBox.Text = "Joydip";
    textBox?.OnTextChanged();
}
