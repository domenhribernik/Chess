namespace ChessProject.PiecesData
{
    public class KnightData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public KnightDirection Direction { get; set; }
        public string Color { get; set; }
    }

    public enum KnightDirection
    {
        LShape
    }
}
