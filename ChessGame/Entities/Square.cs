namespace ChessGame.Entities
{
    class Square
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public SquareColor Color { get; set; }
        public Piece LocalPiece { get; set; }

        public Square()
        {

        }

        public override string ToString()
        {
            if (LocalPiece == null)
                return "-";
            return LocalPiece.ToString();
        }
    }
}