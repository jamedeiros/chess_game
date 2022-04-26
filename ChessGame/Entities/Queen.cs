namespace ChessGame.Entities
{
    class Queen : Piece
    {
        public Queen(Square position, PieceColor color) : base("Q", "Queen", position, color)
        {
        }

        public override bool Move(Square newSquare)
        {
            return false;
        }
    }
}