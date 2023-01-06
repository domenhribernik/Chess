namespace ChessProject.Data
{
    public class Game
    {
        public int GameId { get; set; }
        public int GameTypeId { get; set; }
        public int PlayerWhiteId { get; set; }
        public int PlayerBlackId { get; set; }
        public int TimeLeft { get; set; }
        public string? FinalPosition { get; set; }
        public DateTime PlayedDate { get; set; }
    }
}
