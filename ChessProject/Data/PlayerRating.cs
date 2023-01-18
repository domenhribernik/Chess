namespace ChessProject.Data
{
    public class PlayerRating
    {
        public int PlayerRatingId { get; set; }
        public int PlayerId { get; set; }
        public int RatingTypeId { get; set; }
        public string? RatingType { get; set; }
        public int Rating { get; set; }
        public int NumberOfGames { get; set; }
    }
}
