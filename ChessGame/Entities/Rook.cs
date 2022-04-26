namespace ChessGame.Entities
{
    class Rook : Piece
    {
        public Rook(Square position, PieceColor color) : base("R", "Rook", position, color)
        {
        }

        public override bool Move(Square newSquare)
        {
            return false;
        }
    }
}