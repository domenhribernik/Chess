namespace ChessProject.PiecesData
{
    public class BishopData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public BishopDirection Direction { get; set; }
        public string Color { get; set; }
    }

    public enum BishopDirection
    {
        Diagonally
    }
}
