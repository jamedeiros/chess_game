namespace ChessGame.Entities
{
    class Pawn : Piece
    {
        private bool _moved = false;

        public Pawn(Square position, PieceColor color) : base("P", "Pawn", position, color)
        {
        }

        public override bool Move(Square newSquare)
        {
            return false;
        }
    }
}