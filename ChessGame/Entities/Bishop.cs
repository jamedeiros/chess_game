namespace ChessGame.Entities
{
    class Bishop : Piece
    {
        public Bishop(Square position, PieceColor color) : base("B", "Bishop", position, color)
        {
        }

        public override bool Move(Square newSquare)
        {
            return false;
        }
    }
}