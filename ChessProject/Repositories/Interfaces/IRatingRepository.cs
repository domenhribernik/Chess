using ChessProject.Data;

namespace ChessProject.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<PlayerRating>> RatingLookup(int playerId);
        Task<string> RatingSave(PlayerRating rating);
    }
}
