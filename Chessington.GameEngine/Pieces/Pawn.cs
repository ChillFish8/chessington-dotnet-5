using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved = false;

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
            checkMoved(currentLocation);
            
            var moves = new List<Square>
            {
                Square.At(currentLocation.Row + modifier, currentLocation.Col)
            };

            if (hasMoved) return moves;
            modifier *= 2;
            moves.Add(Square.At(currentLocation.Row + modifier, currentLocation.Col));

            return moves;
        }

        private void checkMoved(Square location)
        {
            if (!hasMoved & Player == Player.White & location.Row != 7)
            {
                hasMoved = true;
            } else if (!hasMoved & Player == Player.Black & location.Row != 1)
            {
                hasMoved = true;
            }
        }
    }
}