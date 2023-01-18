using ChessProject.Data;
using ChessProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChessProject.Repositories
{
    public class RatingRepository : Repository, IRatingRepository
    {
        private ChessDbContext _dbContext;

        public RatingRepository(ChessDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PlayerRating>> RatingLookup(int playerId)
        {
            return await _dbContext.Rating
                .FromSqlRaw("EXEC Chess.Rating_Lookup @PlayerId = {0}", playerId)
                .ToListAsync();
        }

        public async Task<string> RatingSave(PlayerRating rating)
        {
            var savedGame = await _dbContext.Rating
                .FromSqlRaw("EXEC Chess.Rating_Save @PlayerRatingId = {0}, @PlayerId = {1}, @RatingTypeId = {2}, @Rating = {3}, @NumberOfGames = {4}",
                rating.PlayerRatingId, rating.PlayerId, rating.RatingTypeId, rating.Rating, rating.NumberOfGames)
                .ToListAsync();
            return "Successfully saved game";
        }
    }
}
