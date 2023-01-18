namespace ChessProject.Data
{
    public class GameChat
    {
        public int GameChatId { get; set; }
        public int GameId { get; set; }
        public int SendingPlayer { get; set; }
        public string? Username { get; set; }
        public string? Chat { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
