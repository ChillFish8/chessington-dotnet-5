using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var modifier = 1;
            if (Player == Player.White)
            {
                modifier = -1;
            }
            var currentLocation = board.FindPiece(this);
            var moves = new List<Square>
            {
                Square.At(currentLocation.Row + modifier, currentLocation.Col)
            };
            return moves;
        }
    }
}