namespace ChessGame.Entities
{
    class Knight : Piece
    {
        public Knight(Square position, PieceColor color) : base("N", "Knight", position, color)
        {
        }

        public override bool Move(Square newSquare)
        {
            return false;
        }
    }
}