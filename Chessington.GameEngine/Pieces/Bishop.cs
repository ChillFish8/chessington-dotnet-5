using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            var moves = new List<Square>()
            {
                Square.At(currentPosition.Row + 1, currentPosition.Col + 1), // down-right
                Square.At(currentPosition.Row + 1, currentPosition.Col - 1), // down-left
                Square.At(currentPosition.Row - 1, currentPosition.Col + 1), // up-right
                Square.At(currentPosition.Row - 1, currentPosition.Col - 1)  // up-right
            };
            return moves;
        }
    }
}