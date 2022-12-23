namespace ChessProject.Data
{
    public class Player
    {
        public int PlayerId { get; set; }

        public int PlayerTypeId { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public int TotalRating { get; set; }

        public DateTime DateCreatedAccount { get; set; }

        public DateTime DateLastOnline { get; set; }

    }
}
