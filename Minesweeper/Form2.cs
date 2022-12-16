using MinesweeperMilestoneConsoleApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form2 : Form
    {
        static string filepath = @"C:\Users\luberdoodle\source\repos\highscores.txt";
        public int Difficulty { get; set; }
        public int TimeElapsed { get; set; }
        // grid of buttons
        Button[,] btnGrid;
        Board b;
        Stopwatch watch = new Stopwatch();
        public string User { get; set; }
        public int Bombs { get; set; }

        public Form2(int difficulty, string user)
        {
            InitializeComponent();
            btnGrid = new Button[15, 15];
            b = new Board
            {
                Row = 15,
                Col = 15,
                Difficulty = difficulty,
            };
            int numberOfBombs = b.setupBombs();
            b.Grid = b.createBoard(numberOfBombs);
            Bombs = numberOfBombs;
            User = user;
            Difficulty = difficulty;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            watch.Start();
            timer1.Enabled = true;

            // set button size, panel size, form size
            int buttonSize = 30;
            mainPanel.Width = buttonSize * 15;
            mainPanel.Height = mainPanel.Width;
            this.Width = mainPanel.Width + 180;
            this.Height = mainPanel.Height + 100;

            // create board with buttons
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    btnGrid[x, y] = new Button();
                    btnGrid[x, y].BackColor = Color.Gray;
                    btnGrid[x, y].Width = buttonSize;
                    btnGrid[x, y].Height = buttonSize;
                    btnGrid[x, y].MouseUp += Grid_Button_Click;
                    mainPanel.Controls.Add(btnGrid[x, y]);
                    btnGrid[x, y].Location = new Point(x * buttonSize, y * buttonSize);
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


            if(e.Button == MouseButtons.Left)
            {
                if (b.Grid[x, y].Visited == false)
                {
                    // check if bomb is clicked
                    if (b.Grid[x, y].IsBomb)
                    {
                        btnGrid[x,y].BackgroundImage = Minesweeper.Properties.Resources.bomb;
                        btnGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                        b.Grid[x, y].Visited = true;
                    }
                    else
                    {
                        // recursive floodfill to visit open spaces
                        b.floodFill(x, y);
                        b.Grid[x, y].Visited = true;
                        // for loop to visit all visited cells
                        for (int row = 0; row < 15; row++)
                        {
                            for (int col = 0; col < 15; col++)
                            {
                                if (b.Grid[row, col].Visited)
                                {
                                    btnGrid[row, col].BackColor = Color.LightGray;
                                    if(b.Grid[row, col].Neighbors != 0)
                                    {
                                        btnGrid[row, col].Text = b.Grid[row, col].Neighbors.ToString();
                                    }
                                }
                            }
                        }
                    }
                    // check game condition
                    // check if bombs are clicked
                    bool gameover = b.checkForBomb();
                    bool win = false;
                    if (gameover)
                    {
                        gameLost();
                    }
                    else
                    {
                        // check for number of flags
                        if (b.checkForFlags() == Bombs)
                        {
                            win = b.checkForWin();
                        }
                    }
                    if(win)
                    {
                        gameWon();
                    }
                   
                }
            }
            else if(e.Button == MouseButtons.Right && !b.Grid[x, y].Visited)
            {
                b.Grid[x, y].Flag = !b.Grid[x, y].Flag;
                for(int row = 0; row < 15; row++)
                {
                    for(int col = 0; col < 15; col++)
                    {
                        if (b.Grid[row, col].Flag == true && b.Grid[row,col].Visited == false)
                        {
                            btnGrid[row, col].BackColor = Color.Yellow;
                        }
                        else if (b.Grid[row, col].Flag == false && b.Grid[row, col].Visited == false)
                        {
                            btnGrid[row, col].BackColor = Color.Gray;
                        }
                    }
                }
                // check game condition
                // check if bombs are clicked
                bool gameover = b.checkForBomb();
                bool win = false;
                if (gameover)
                {
                    gameLost();
                }
                else
                {
                    // check for number of flags
                    if (b.checkForFlags() == Bombs)
                    {
                        win = b.checkForWin();
                    }
                }
                if (win)
                {
                    gameWon();
                }
            }
        }

        private void gameLost()
        {
            watch.Stop();
            // show all bombs:
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (b.Grid[x, y].IsBomb)
                    {
                        btnGrid[x, y].BackgroundImage = Minesweeper.Properties.Resources.bomb;
                        btnGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            MessageBox.Show("You lost!");
            this.Close();
        }

        private void gameWon()
        {
            watch.Stop();

            int score = (20 * Difficulty) - TimeElapsed;
            PlayerStats player = new PlayerStats
            {
                User = User,
                Difficulty = Difficulty,
                Time = TimeElapsed,
                Score = score
            };


            List<String> lines = File.ReadAllLines(filepath).ToList();
            // write players to file:
            using (StreamWriter file = new StreamWriter(filepath))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<PlayerStats>(line)));
                }
                string output = JsonConvert.SerializeObject(player);
                file.WriteLine(output);
            }


            MessageBox.Show("You Won! You got a score of " + player.Score);
            this.Close();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeElapsed = (int) watch.ElapsedMilliseconds / 1000;
            lbl_stopwatch.Text = TimeElapsed.ToString();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
