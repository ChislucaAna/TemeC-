using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrosswordGame
{
    public partial class AddNewWord : Form
    {
        public AddNewWord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(System.Environment.NewLine) || textBox1.Text.Contains(" ") || textBox1.Text.Any(Char.IsDigit)
            || textBox1.Text.Any(Char.IsUpper))
            {
                MessageBox.Show("Please only write one word in the Word box. No new lines,extra spaces, numbers or capital letters allowed.");
                return;
            }

            if (textBox2.Text.Contains(System.Environment.NewLine))
            {
                MessageBox.Show("Please don't add any new lines in the description box.");
                return;
            }

            StreamWriter streamWriter = new StreamWriter("words.txt", true);
            streamWriter.WriteLine(textBox1.Text + ";" +textBox2.Text + ";");
            streamWriter.Close();
        }
    }
}
