using System;
namespace ULTTikTakToe.Logic;

public class Board
{
    private string[,] grid;
    public string Winner { get; private set; }
    public bool IsFull { get; private set; }

    public Board()
    {
        grid = new string[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                grid[i, j] = ""; 

        Winner = null;
        IsFull = false;
    }

    public bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && string.IsNullOrEmpty(grid[row, col]);
    }

    public void PlaceMarker(string player, int row, int col)
    {
        if (!IsValidMove(row, col))
        {
            throw new InvalidOperationException("Invalid move! This spot is already in use by the other player.");
        }

        grid[row, col] = player;
        CheckWinner();
        CheckIfFull();
    }

    public string GetCellContent(int row, int col)
    {
        if (row >= 0 && row < 3 && col >= 0 && col < 3)
        {
            return grid[row, col];
        }
        throw new ArgumentOutOfRangeException("Row and Column must be within the range 0-2.");
    }

    public void CheckWinner()
    {
        string[][] lines =
        {
            // Rows
            new string[] { grid[0, 0], grid[0, 1], grid[0, 2] },
            new string[] { grid[1, 0], grid[1, 1], grid[1, 2] },
            new string[] { grid[2, 0], grid[2, 1], grid[2, 2] },
            // Columns
            new string[] { grid[0, 0], grid[1, 0], grid[2, 0] },
            new string[] { grid[0, 1], grid[1, 1], grid[2, 1] },
            new string[] { grid[0, 2], grid[1, 2], grid[2, 2] },
            // Diagonals
            new string[] { grid[0, 0], grid[1, 1], grid[2, 2] },
            new string[] { grid[0, 2], grid[1, 1], grid[2, 0] }
        };

        foreach (var line in lines)
        {
            if (!string.IsNullOrEmpty(line[0]) && line[0] == line[1] && line[1] == line[2])
            {
                Winner = line[0];
                return;
            }
        }
    }

    private void CheckIfFull()
    {
        IsFull = true;

        foreach (var cell in grid)
        {
            if (string.IsNullOrEmpty(cell))
            {
                IsFull = false;
                break;
            }
        }
    }

    public void DisplayBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write(grid[row, col] ?? " ");
                if (col < 2) Console.Write(" | ");
            }

            Console.WriteLine();
            if (row < 2) Console.WriteLine("---------");
        }
    }
}
