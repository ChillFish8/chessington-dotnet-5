using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        private readonly int _modifier = 1;
        private Square _currentLocation;
        private Board _board;

        private readonly List<Action> _pipeline;
        public Pawn(Player player)
            : base(player)
        {
            if (Player == Player.White)
            {
                _modifier = -1;
            }

            _pipeline = new List<Action>
            {
                CheckMoved,
            };
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            _board = board;
            _currentLocation = board.FindPiece(this);
            InvokePipeline();
            
            if (!SpaceClear())
            {
                return new List<Square>();
            }
            
            var moves = new List<Square>
            {
                GetNextSquare()
            };

            if (_hasMoved) return moves;
            
            if (SpaceClear(2))
                moves.Add(GetNextSquare(2));

            return moves;
        }

        private void InvokePipeline()
        {
            foreach (var action in _pipeline)
            {
                action();
            }
        }

        private Square GetNextSquare(int boost = 1)
        {
            return Square.At(_currentLocation.Row + (_modifier * boost), _currentLocation.Col);
        }

        private bool SpaceClear(int lookAhead = 1)
        {
            var next = GetNextSquare(lookAhead);
            return _board.GetPiece(next) is null;
        }

        private void CheckMoved()
        {
            if (!_hasMoved & Player == Player.White & _currentLocation.Row != 7)
            {
                _hasMoved = true;
            } else if (!_hasMoved & Player == Player.Black & _currentLocation.Row != 1)
            {
                _hasMoved = true;
            }
        }
    }
}