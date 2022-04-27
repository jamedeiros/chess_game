namespace ChessGame.Entities
{
    abstract class Piece
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public Square Position { get; set; }
        public PieceColor Color { get; set; }

        private Piece()
        {

        }

        public Piece(string symbol, string name, Square position, PieceColor color)
        {
            Symbol = symbol;
            Name = name;
            Position = position;
            Color = color;

            Position.LocalPiece = this;
        }

        public void MoveTo(Square newPosition) 
        {
            Position.LocalPiece = null;
            newPosition.LocalPiece = this;
        }

        public override string ToString()
        {
            return Symbol;
        }
    }
}