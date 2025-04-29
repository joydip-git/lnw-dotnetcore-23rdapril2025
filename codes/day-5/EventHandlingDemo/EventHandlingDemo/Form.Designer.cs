namespace EventHandlingDemo
{
    public partial class Form
    {
        private List<Control> controls;
        private TextBox nameTextBox;
        private void InitializeComponent()
        {
            controls = [];

            nameTextBox = new();
            nameTextBox.Id = "nameTextBox";
            nameTextBox.Name = "Name";
            nameTextBox.Position = new System.Drawing.Point(100, 200);
            nameTextBox.TextChanged += new ControlEventHandler(this.GeTextBoxData);

            controls.Add(nameTextBox);
        }
        public List<Control> Controls => controls;
    }
}
