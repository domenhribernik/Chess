namespace ChessProject.PiecesData
{
    public class PawnData
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public PawnDirection Direction { get; set; }
        public string Color { get; set; }
    }

    public enum PawnDirection
    {
        Up, Diagonal, Down
    }
}
