using System;
namespace ULTTikTakToe.Logic;

public class Game
{
    public Board Board { get; private set; }
    public string CurrentPlayer;

    public Game()
    {
        Board = new Board();
        CurrentPlayer = "X";
    }

    public void MakeMove(int row, int col)
    {
        Board.PlaceMarker(CurrentPlayer, row, col);
        SwitchPlayer();
    }

    public string GetWinner()
    {
        return Board.Winner;
    }

    private void SwitchPlayer()
    {
        CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
    }

    public void PlayGame()
    {
        while (Board.Winner == null && !Board.IsFull)
        {
            Console.Clear();
            Board.DisplayBoard();

            Console.WriteLine($"Player {CurrentPlayer}'s turn.");
            Console.Write("Enter row (0, 1, 2): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter column (0, 1, 2): ");
            int col = int.Parse(Console.ReadLine());

            try
            {
                MakeMove(row, col);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.Clear();
        Board.DisplayBoard();

        if (Board.Winner != null)
        {
            Console.WriteLine($"Player {Board.Winner} wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
    }
}


