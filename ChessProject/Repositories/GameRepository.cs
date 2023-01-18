using ChessProject.Data;
using ChessProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
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

        public async Task<List<Game>> GetPlayerGames(int playerId)
        {
            return await _dbContext.Game
                .FromSqlRaw("EXEC Chess.Game_Player_List @PlayerId = {0}", playerId)
                .ToListAsync();
        }

        public async Task<Game> GameLookup(int gameId)
        {
            var game = await _dbContext.Game
                .FromSqlRaw("EXEC Chess.Game_Lookup @GameId = {0}", gameId)
                .ToListAsync();
            return game.SingleOrDefault();
        }

        public async Task<string> GameSave(Game game)
        {
            var savedGame = await _dbContext.Game
                .FromSqlRaw("EXEC Chess.Game_Save @GameId = {0}, @GameTypeId = {1}, @PlayerWhiteId = {2}, @PlayerBlackId = {3}, @TimeLeftWhite = {4}, @TimeLeftBlack = {5}, @FinalPosition = {6}, @PlayedDate = {7}",
                game.GameId, game.GameTypeId, game.PlayerWhiteId, game.PlayerBlackId, game.TimeLeftWhite, game.TimeLeftBlack, game.FinalPosition, game.PlayedDate)
                .ToListAsync();
            return "Successfully saved game";
        }
    }
}