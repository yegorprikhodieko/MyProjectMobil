using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FindPair
{
    public partial class Form1 : Form
    {

        TimeSpan interval = new TimeSpan(0, 0, 2);
        public int height, width,complex =1;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "1", "2", "3", "4" });

        }
       
        public bool n = true;
        int locX = 100, locY = 50;
        private void button1_Click(object sender, EventArgs e)
        {
            if (n)
            {
                Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                //for (int i = 0; i < width; i++)
                //{
                //    for (int j = 0; j < height; j++)
                //    {
                //        Button btn = new Button();
                //        btnCell[i, j] = My_Button(btn, locX, locY, 50, 50, Click);
                //        locX += 50;
                         
                //    }
                //    locX = 100;
                //    locY += 50;
                //}
                //n = true;
            }
            //int[] redX = new int[4];
            //int[] redY= new int[4];
            //Random rnd = new Random();
            //for (int i = 0; i < 4; i++)
            //{                
            //    int randX = rnd.Next(1, width);
            //    int randY = rnd.Next(1, height);
            //    redX[i] = randX-1;
            //    redY[i] = randY-1;
            //}
            //Thread.Sleep(interval);
            //for (int i = 0; i < width; i++)
            //{

            //    for (int j = 0; j < height; j++)
            //    {
            //        for (int k = 0; k < redX.Length; k++)
            //        {
            //            if (i == redX[k] && j == redY[k])
            //            {
            //                btnCell[i,j].BackColor = Color.Red;
                            

            //            }
            //        }
            //    }
                
                
            //}
            n = true;


        }
        int[] redX = new int[5];
        int[] redY = new int[5];

        int[] _lockationX = new int[5];
        int[] _lockationY = new int[5];
        Button[,] btnCell = new Button[10, 10];
        private void button2_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text == "1")
            {
                width = 4;
                height = 4;

            }
            if (comboBox1.Text == "2")
            {
                width = 6;
                height = 6;

            }
            if (comboBox1.Text == "3")
            {
                width = 8;
                height = 8;

            }
            if (comboBox1.Text == "4")
            {
                width = 10;
                height = 10;

            }


            if (width == 0 || height == 0)
            {
                MessageBox.Show("Сначала задайте размер и сложность!");
            }
            else
            {


                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Button btn = new Button();
                        btnCell[i, j] = My_Button(btn, locX, locY, 50, 50, Click);
                        locX += 50;

                    }
                    locX = 100;
                    locY += 50;
                }
                locX = 100; locY = 50;
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    int randX = rnd.Next(1, width);
                    int randY = rnd.Next(1, height);
                    for (int j = 0; j < 5; j++)
                    {
                        if (redX[j] == randX && redY[j] == randY)
                        {
                            i--;
                        }
                        else
                        {
                            redX[i] = randX - 1;
                            redY[i] = randY - 1;
                        }
                    }
                    

                }
                // Thread.Sleep(interval);
                int schet = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        for (int k = 0; k < redX.Length; k++)
                        {
                            if (i == redX[k] && j == redY[k])
                            {
                                btnCell[i, j].BackColor = Color.Red;
                                _lockationX[schet] = btnCell[i,j].Location.X;
                                _lockationY[schet] = btnCell[i,j].Location.Y;
                                schet++;


                            }
                        }
                    }


                }
                schet = 0;
            }
            
            this.Refresh();
            Thread.Sleep(5000);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    btnCell[i, j].BackColor = Color.Green;
                }
            }
            this.Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    panel1.Controls.Remove(btnCell[i, j]);
                }
            }
        }
        public Button My_Button(Button btn, int x, int y, int w, int h, EventHandler e)
        {
            btn = new Button();


            btn.BackColor = Color.Green;
            btn.Text = "1";
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.Click += e;
            


            panel1.Controls.Add(btn);
            return btn;
        }
        public int win = 0 ;
        public void Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           
                for (int k = 0; k < _lockationX.Length; k++)
                {
                    if (btn.Location.X == _lockationX[k] && btn.Location.Y == _lockationY[k])
                    {
                        btn.BackColor = Color.Yellow;
                        win++;
                        if (win == _lockationX.Length)
                        {
                            MessageBox.Show("Win!!!!");
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    panel1.Controls.Remove(btnCell[i, j]);
                                }
                            }

                        }
                        break;


                    }
                    else
                    {
                        btn.BackColor = Color.Gray;
                    }
                }
          
            this.Refresh();
           // MessageBox.Show("Hi");
        }
    }
}
