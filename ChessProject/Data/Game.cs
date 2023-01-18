namespace ChessProject.Data
{
    public class Game
    {
        public int GameId { get; set; }
        public int GameTypeId { get; set; }
        public string? GameType { get; set; }
        public int PlayerWhiteId { get; set; }
        public string? UsernameWhite { get; set; }
        public int PlayerBlackId { get; set; }
        public string? UsernameBlack { get; set; }
        public int TimeLeftWhite { get; set; }
        public int TimeLeftBlack { get; set; }
        public string? FinalPosition { get; set; }
        public DateTime PlayedDate { get; set; }
    }
}
