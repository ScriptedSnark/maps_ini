using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace maps_ini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllLines(@".\\maps.txt", Directory.GetFiles(textBox1.Text, "*.bsp").Select(x => Path.GetFileNameWithoutExtension(x)).ToArray());
                MessageBox.Show(
"Все карты записаны в maps.txt файл. Найти его сможете в папке с maps_ini.exe.",
"maps_ini",
MessageBoxButtons.OK,
MessageBoxIcon.Information,
MessageBoxDefaultButton.Button1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(
     ex.Message,
     "maps_ini",
     MessageBoxButtons.OK,
     MessageBoxIcon.Error,
     MessageBoxDefaultButton.Button1);
            }
        }
    }
}
