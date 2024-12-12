namespace RGB_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generate_rgb(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(trackBar1.Value, (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            pictureBox1.BackColor = c;
            label3.Text = trackBar1.Value.ToString();
        }
    }
}
