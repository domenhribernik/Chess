namespace ChessProject.PiecesData
{
    public class KingData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public KingDirection Direction { get; set; }
        public string Color { get; set; }
    }

    public enum KingDirection
    {
        OneAny
    }
}
