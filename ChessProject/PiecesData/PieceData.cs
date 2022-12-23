namespace ChessProject.PiecesData
{
    public class PieceData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Direction Direction { get; set; }
        public string Color { get; set; }
        public Type Type { get; set; }
    }

    public enum Direction
    {
        Up, Diagonal, Down, Diagonally, OneAny, LShape, Any, Straight
    }

    public enum Type
    {
        Pawn, Bishop, King, Knight, Rook, Queen
    }
}
