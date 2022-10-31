using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form2 : Form
    {
        static int size_x = 13;
        static int size_y = 9;
        static Form2 frm = new Form2();
        // grid of buttons
        public Button[,] btnGrid = new Button[size_x, size_y];


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            int buttonSize = mainPanel.Width / size_x;
            mainPanel.Height = mainPanel.Width;

            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    btnGrid[x, y] = new Button();
                    btnGrid[x, y].Width = buttonSize;
                    btnGrid[x, y].Height = buttonSize;

                    btnGrid[x, y].MouseUp += Grid_Button_Click;

                    mainPanel.Controls.Add(btnGrid[x, y]);
                    btnGrid[x, y].Location = new Point(x * buttonSize, y * buttonSize);
                    //btnGrid[x, y].Text = x + "|" + y;
                    btnGrid[x, y].Text = "0";

                    btnGrid[x, y].Tag = new Point(x, y);
                }
            }
        }

        private void Grid_Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            int num = Int32.Parse(btnGrid[x, y].Text);
            if(e.Button == MouseButtons.Left)
            {
                num++;
                btnGrid[x, y].Text = num.ToString();
            }
            else if(e.Button == MouseButtons.Right)
            {
                num--;
                btnGrid[x, y].Text = num.ToString();
            }

        }
    }
}
