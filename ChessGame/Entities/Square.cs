namespace ChessGame.Entities
{
    class Square
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public SquareColor Color { get; set; }

        public Square()
        {

        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Row, Col);
        }
    }
}