using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestUpdate()
        {
            Board board = new Board();
            board.Update(5, "X");
            Assert.Equal("X", board.Squares[1, 1].Content);
        }

        [Theory]
        [InlineData(0, "X")]
        [InlineData(1, "O")]
        [InlineData(2, "X")]
        public void TestSwitchPlayers(int turnNum, string marker)
        {
            Game game = new Game();
            Assert.Equal(marker, game.GetPlayer(turnNum).Marker);
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(1,4,7)]
        [InlineData(1,5,9)]
        [InlineData(3,6,9)]
        [InlineData(2,5,8)]
        [InlineData(3,5,7)]
        [InlineData(4,5,6)]
        [InlineData(7,8,9)]
        public void TestWinner(int pos1, int pos2, int pos3)
        {
            Board board = new Board();
            board.Update(pos1, "X");
            board.Update(pos2, "X");
            board.Update(pos3, "X");
            Assert.Equal("X", board.CheckWinner());
        }

        [Fact]
        public void TestSpaceTaken()
        {
            Board board = new Board();
            board.Update(5, "X");
            Assert.False(board.Update(5, "O"));
        }
    }
}
