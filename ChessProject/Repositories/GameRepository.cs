using ChessProject.Data;
using ChessProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ChessProject.Repositories
{
    public class GameRepository : Repository, IGameRepository
    {
        private ChessDbContext _dbContext;

        public GameRepository(ChessDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Game>> GetGames()
        {
            return await _dbContext.Game
                .FromSqlRaw("EXEC Chess.Game_List")
                .ToListAsync();
        }

        public async Task<Game> GameLookup(int gameId)
        {
            try
            {
                var game = await _dbContext.Game
                .FromSqlRaw("EXEC Chess.Game_Lookup @GameId = {0}", gameId)
                .ToListAsync();
                return game.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GameSave(Game game)
        {

            return "Game saved";
        }
    }
}