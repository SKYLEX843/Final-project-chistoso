namespace ULTTikTakToe.Logic;

public class GameService
{
    public readonly Game Game;

    public GameService()
    {
        Game = new Game();
    }

    public string GetCellContent(int row, int col)
    {
        return Game.Board.GetCellContent(row, col);
    }

    public void MakeMove(int row, int col)
    {
        Game.MakeMove(row, col);
    }

    public string GetWinner()
    {
        return Game.GetWinner();
    }
}



