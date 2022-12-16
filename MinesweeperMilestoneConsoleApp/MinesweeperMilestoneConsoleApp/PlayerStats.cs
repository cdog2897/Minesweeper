using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMilestoneConsoleApp
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string User { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public int Difficulty { get; set; }

        public PlayerStats()
        {
        }
        public PlayerStats(string user, int score, int time, int difficulty)
        {
            User = user;
            Score = score;
            Time = time;
            Difficulty = difficulty;
        }

        public int CompareTo(PlayerStats player)
        {
            if (this.Score < player.Score)
            {
                return 1;
            }
            else if (this.Score > player.Score)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
