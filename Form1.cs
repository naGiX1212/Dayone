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
        private List<string> str = Directory.GetFiles(@"D:\Rouzed\S").Where(a => a.EndsWith(".jpg") || a.EndsWith(".png")).ToList();
        private int i = 0;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.BackgroundImage = Image.FromFile(str[i]);
            this.KeyDown += Form1_KeyDown;


        }

        private void Form1_Click(object sender, EventArgs e)
        {

            try
            {
                i++;
                this.BackgroundImage = Image.FromFile(str[i]);
                if (i >= str.Count())
                {
                    i = 0;
                }
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
            if (e.KeyCode == Keys.Space)
            {
                this.Form1_Click(sender,e);
            }
        }
    }
}
