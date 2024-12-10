using Xunit;
public class GameTests
{
    [Fact]
    public void MakeMove_ShouldUpdateBoardCorrectly()
    {
 
        var game = new Game();

      
        game.MakeMove(0, 0); 

        
        Assert.Equal("X", game.Board.GetCellContent(0, 0));
    }

    [Fact]
    public void MakeMove_ShouldSwitchPlayerAfterMove()
    {
       
        var game = new Game();

       
        game.MakeMove(0, 0); 
        game.MakeMove(1, 1); 

        
        Assert.Equal("O", game.Board.GetCellContent(1, 1));
    }

    [Fact]
    public void GetWinner_ShouldReturnWinner_WhenWinningConditionMet()
    {
        
        var game = new Game();
        
        game.MakeMove(0, 0); 
        game.MakeMove(1, 0); 
        game.MakeMove(0, 1); 
        game.MakeMove(1, 1); 
        game.MakeMove(0, 2);

        Assert.Equal("X", game.GetWinner());
    }

    [Fact]
    public void GetWinner_ShouldReturnNull_WhenNoWinnerYet()
    {

        var game = new Game();

        game.MakeMove(0, 0); // X
        game.MakeMove(1, 0); // O
        game.MakeMove(0, 1); // X

        Assert.Null(game.GetWinner());
    }
}

public class BoardTests
{
    [Fact]
    public void GetCellContent_ShouldReturnEmptyString_Initially()
    {
        
        var board = new Board();

        Assert.Equal("", board.GetCellContent(0, 0));
        Assert.Equal("", board.GetCellContent(1, 1));
    }

    [Fact]
    public void PlaceMarker_ShouldSetCorrectValue()
    {

        var board = new Board();

        board.PlaceMarker("X", 0, 0);

        Assert.Equal("X", board.GetCellContent(0, 0));
    }

    [Fact]
    public void PlaceMarker_ShouldThrowException_IfCellAlreadyOccupied()
    {

        var board = new Board();
        board.PlaceMarker("X", 0, 0);

        Assert.Throws<InvalidOperationException>(() => board.PlaceMarker("O", 0, 0));
    }

    [Fact]
    public void CheckWinner_ShouldIdentifyHorizontalWin()
    {

        var board = new Board();
        board.PlaceMarker("X", 0, 0);
        board.PlaceMarker("X", 0, 1);
        board.PlaceMarker("X", 0, 2);

        board.CheckWinner();

        Assert.Equal("X", board.Winner);
    }

    [Fact]
    public void CheckWinner_ShouldIdentifyVerticalWin()
    {

        var board = new Board();
        board.PlaceMarker("O", 0, 0);
        board.PlaceMarker("O", 1, 0);
        board.PlaceMarker("O", 2, 0);

        board.CheckWinner();

        Assert.Equal("O", board.Winner);
    }

    [Fact]
    public void CheckWinner_ShouldIdentifyDiagonalWin()
    {
        var board = new Board();
        board.PlaceMarker("X", 0, 0);
        board.PlaceMarker("X", 1, 1);
        board.PlaceMarker("X", 2, 2);

        board.CheckWinner();

        Assert.Equal("X", board.Winner);
    }

    [Fact]
    public void CheckWinner_ShouldReturnNull_WhenNoWinner()
    {

        var board = new Board();
        board.PlaceMarker("X", 0, 0);
        board.PlaceMarker("O", 1, 1);
        board.PlaceMarker("X", 2, 2);

        board.CheckWinner();

        Assert.Null(board.Winner);
    }
}

