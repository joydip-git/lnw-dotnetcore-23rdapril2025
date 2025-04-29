namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Get(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var txt = (TextBox)sender;
                MessageBox.Show(txt.Text);
            }
        }
    }
}
