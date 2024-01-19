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

namespace DayOne
{
    public partial class Form1 : Form
    {
        //Cambiar "D:\Rouzed\S" por su directorio donde se encuntrar sus imagenes
        List<string> str;
        private DirectoryInfo info = new DirectoryInfo(@"D:\Rouzed\S");
        private int i = 0;
        public Form1()
        {
            InitializeComponent();
            FileInfo[] files = info.GetFiles().OrderByDescending(p => p.LastWriteTime).ToArray();
            str = files.Where(a => a.Extension == ".jpg" || a.Extension == ".png").Select(a => a.FullName).ToList();
            if (str != null)
            {
                this.KeyPreview = true;
                this.BackgroundImage = Image.FromFile(str[i]);
                this.KeyDown += Form1_KeyDown;
            }


        }

        private void Form1_Click(object sender, EventArgs e)
        {

            try
            {
                if(i<0)
                {
                    i = str.Count()-1;
                }
                
                if (i >= str.Count())
                {
                    i = 0;
                }
                this.BackgroundImage.Dispose();
                this.BackgroundImage = Image.FromFile(str[i]);

            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
                throw;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Suppose when User Press Ctrl + J then Click Button1
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Right)
            {
                i++;
                this.Form1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Left)
            {
                i--;
                this.Form1_Click(sender, e);
            }
        }
    }
}
