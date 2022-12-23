namespace ChessProject.PiecesData
{
    public class QueenData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public QueenDirection Direction { get; set; }
        public string Color { get; set; }
    }

    public enum QueenDirection
    {
        Any
    }
}
