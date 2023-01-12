using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindPair
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[] { "1", "2","3","4" });
        }
        int locX = 100, locY = 50;
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();

            Form1 f1=  new Form1();

            f1.width = Convert.ToInt32(textBox1.Text);
            f1.height = Convert.ToInt32(textBox2.Text);
            f1.complex = Convert.ToInt32(comboBox1.Text);
            f1.n = false;
            for (int i = 0; i < f1.width; i++)
            {
                for (int j = 0; j < f1.height; j++)
                {
                   // Button btn = new Button();
                    //f1.btnCell[i, j] = f1.My_Button(btn, locX, locY, 50, 50, f1.Click);
                    locX += 50;

                }
                locX = 100;
                locY += 50;
            }
           

            f1.ShowDialog();
            
        }
    }
}
