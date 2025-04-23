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

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fullPath, directoryPath;
        string[] mediaExtensions = { ".mp4", ".mp3", ".avi", ".mov", ".wav", ".mkv" };

        private void Select(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string filePath = listView1.SelectedItems[0].Text;
                axWindowsMediaPlayer1.URL = new Uri(filePath).AbsoluteUri;
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppContext.BaseDirectory;
            openFileDialog.Filter = "Media files (*.mp4;*.mp3;*.avi;*.mov;*.wav;*.mkv)|*.mp4;*.mp3;*.avi;*.mov;*.wav;*.mkv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fullPath=openFileDialog.FileName; 
                directoryPath = Path.GetDirectoryName(fullPath);
            }
            var list = Directory
            .GetFiles(directoryPath)
            .Where(file => mediaExtensions.Contains(Path.GetExtension(file).ToLower()))
            .ToList();
            foreach (var file in list)
            {
                listView1.Items.Add(file);
            }
        }
    }
}
