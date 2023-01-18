using ChessProject.Data;
using ChessProject.Repositories.Interfaces;

namespace ChessProject.Services
{
    public class RatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task<List<PlayerRating>> RatingLookup(int playerId)
        {
            return await _ratingRepository.RatingLookup(playerId);
        }

        public async Task<string> RatingSave(PlayerRating rating)
        {
            return await _ratingRepository.RatingSave(rating);
        }
    }
}
