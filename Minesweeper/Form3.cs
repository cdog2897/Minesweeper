using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using MinesweeperMilestoneConsoleApp;
using Newtonsoft.Json;

namespace Minesweeper
{
    public partial class Form3 : Form
    {
        public PlayerStats Player { get; set; }
        static string filepath = @"C:\Users\luberdoodle\source\repos\highscores.txt";

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(PlayerStats player)
        {
            Player = player;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            List<String> updatedlines = File.ReadAllLines(filepath).ToList();
            List<PlayerStats> players = new List<PlayerStats>();

            for(int i = 0; i < updatedlines.Count; i++)
            {
                // deserialize json
                PlayerStats p = JsonConvert.DeserializeObject<PlayerStats>(updatedlines[i]);
                players.Add(p);
            }

            players.Sort();

            // use LINQ to take top 5
            var topPlayers =
                (from player in players
                select player).Take(5);

            for (int i = 0; i < 5; i++)
            {
                Label lbl = new Label();
                lbl.Location = new Point(30, 70 + (i * 30));
                lbl.Text = (i + 1).ToString();
                lbl.AutoSize = true;
                lbl.Font = new Font("Atari Classic", 10, FontStyle.Regular);
                this.Controls.Add(lbl);
            }

            int index = 0;
            foreach(var player in topPlayers)
            {
                Label label = new Label();
                label.Location = new Point(60, 70 + (index * 30));
                label.Text = player.User;
                label.AutoSize = true;
                label.Font = new Font("Atari Classic", 10, FontStyle.Regular);
                this.Controls.Add(label);

                Label score = new Label();
                score.Location = new Point(this.Width - 130, 70 + (index * 30));
                score.Text = player.Score.ToString();
                score.AutoSize = true;
                score.Font = new Font("Atari Classic", 10, FontStyle.Regular);
                this.Controls.Add(score);
                index++;
            }

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
