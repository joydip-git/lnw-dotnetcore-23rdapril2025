namespace EventHandlingDemo
{
    public partial class Form : Control
    {

        public Form()
        {
            InitializeComponent();
        }

        private void GeTextBoxData(object obj, ControlEventArgs e)
        {
            if (obj is TextBox)
            {
                TextBox? txt = obj as TextBox;
                Console.WriteLine($"value entered in {txt?.GetType().Name} and the entered value is {e.EventArgs}");
            }

        }
        //partial void InitializeComponent();
    }
}
