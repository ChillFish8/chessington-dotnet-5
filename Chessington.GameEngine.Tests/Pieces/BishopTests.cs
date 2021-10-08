using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    { 
        [Test]
        public void Bishop_CanMoveDiagonalOneSquareUpRight()
        {
            var board = new Board();
            var pawn = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 2), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 3));
        }

        [Test]
        public void Bishop_CanMoveDiagonalOneSquareUpLeft()
        {
            var board = new Board();
            var pawn = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 2), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 1));
        }
        
        [Test]
        public void Bishop_CanMoveDiagonalOneSquareDownRight()
        {
            var board = new Board();
            var pawn = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 2), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 3));
        }
        
        [Test]
        public void Bishop_CanMoveDiagonalOneSquareDownLeft()
        {
            var board = new Board();
            var pawn = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 2), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 1));
        }
    }
}