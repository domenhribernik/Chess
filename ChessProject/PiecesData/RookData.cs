namespace ChessProject.PiecesData
{
    public class RookData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public RookDirection Direction { get; set; }
        public string Color { get; set; }
    }

    public enum RookDirection
    {
        Straight
    }
}
