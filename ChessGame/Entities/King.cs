namespace ChessGame.Entities
{
    class King : Piece
    {
        public King(Square position, PieceColor color) : base("K", "King", position, color)
        {
        }

        public override bool Move(Square newSquare)
        {
            return false;
        }
    }
}