using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMilestoneConsoleApp
{
    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Visited { get; set; }
        public bool IsBomb { get; set; }
        public int Neighbors { get; set; }
        public bool Flag { get; set; }

        // defualt
        public Cell()
        {
            Row = -1;
            Col = -1;
            Visited = false;
            IsBomb = false;
            Neighbors = 0;
            Flag = false;
        }


        public override string ToString()
        {
            if(IsBomb)
            {
                return "| * ";
            }
            else
            {
                return "| " + Neighbors + " ";
            }
        }

    }
}
