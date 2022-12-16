using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMilestoneConsoleApp
{
    public class Board
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Cell[,] Grid { get; set; }
        public int Difficulty { get; set; }


        // default
        public Board()
        {
            Row = 0;
            Col = 0;
            Grid = null;
            Difficulty = 0;
        }

        //parameterized
        public Board(int row, int col, Cell[,] grid, int difficulty)
        {
            Row = row;
            Col = col;
            Grid = grid;
            Difficulty = difficulty;
        }


        // methods:
        public Cell[,] createBoard(int numBombs)
        {
            Cell[,] grid = new Cell[Row, Col];

            // create cells using for loop
            for (int x = 0; x < Row; x++)
            {
                for(int y = 0; y < Col; y++)
                {
                    Cell cell = new Cell();
                    cell.Row = x;
                    cell.Col = y;
                    cell.Visited = false;
                    cell.IsBomb = false;
                    cell.Neighbors = 0;

                    grid[x, y] = cell;
                }
            }
            Random random = new Random();
            for (int i = 0; i < numBombs; i++)
            {
                bool isBombAlreadyThere = true;
                while(isBombAlreadyThere)
                {
                    int ranRow = random.Next(grid.GetLength(0));
                    int ranCol = random.Next(grid.GetLength(1));
                    if (grid[ranRow, ranCol].IsBomb == false)
                    {
                        grid[ranRow, ranCol].IsBomb = true;
                        isBombAlreadyThere = false;
                    }
                }
            }

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    grid[x, y].Neighbors = createNeighbor(grid[x, y], grid);
                }
            }
            return grid;
        }

        public int createNeighbor(Cell cell, Cell[,] grid)
        {
            int neighbor = 0;
            for(int i = cell.Row - 1; i < cell.Row + 2; i++)
            {
                for(int j = cell.Col - 1; j < cell.Col + 2; j++)
                {
                    try
                    {
                        if (grid[i, j].IsBomb == true)
                        {
                            neighbor++;
                        }
                    }
                    catch { }
                }
            }
            return neighbor;
        }

        // use difficulty and size to determine how many bombs to place
        public int setupBombs()
        {
            return Difficulty;
            //double multiplier = (double) Difficulty / 100;
            //int num = Row * Col;
            //int numOfBombs = (int) (num * multiplier);
            //return numOfBombs;
        }

        public void floodFill(int x, int y)
        {
            if (isValid(x, y) && Grid[x, y].Visited == false)
            {
                Grid[x, y].Visited = true;

                if (Grid[x, y].Neighbors == 0)
                {
                    floodFill(x + 1, y);
                    floodFill(x, y + 1);
                    floodFill(x - 1, y);
                    floodFill(x, y - 1);
                }
            }
        }

        public bool isValid(int x, int y)
        {
            if(x >= 0 && x < Row && y >= 0 && y < Col)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool checkForWin()
        {
            bool win = true;
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.GetLength(1); y++)
                {
                    if (Grid[x,y].IsBomb == true && Grid[x,y].Flag == false)
                    {
                        win = false;
                    }
                    if(Grid[x, y].IsBomb == false && Grid[x, y].Flag == true)
                    {
                        win = false;
                    }
                }
            }
            return win;
        }

        public bool checkForBomb()
        {
            bool gameOver = false;
            // check to see if a bomb has been visited.
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.GetLength(1); y++)
                {
                    // check if bombs are clicked
                    if (Grid[x, y].Visited == true && Grid[x, y].IsBomb == true)
                    {
                        gameOver = true;
                    }
                }
            }
            return gameOver;
        }

        public int checkForFlags()
        {
            int counter = 0;
            for(int x = 0; x < Grid.GetLength(0); x++)
            {
                for(int y = 0; y < Grid.GetLength(1); y++)
                {
                    if(Grid[x, y].Flag == true)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

    }
}
