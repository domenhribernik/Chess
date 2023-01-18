using ChessProject.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;
using ChessProject.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace ChessProject.Repositories
{
    public class PlayerRepository : Repository, IPlayerRepository
    {
        private ChessDbContext _dbContext;

        public PlayerRepository(ChessDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _dbContext.Player
                .FromSqlRaw("EXEC Chess.Player_List")
                .ToListAsync();
        }

        public async Task<Player> PlayerLookup(int playerId)
        {
            try
            {
                var player = await _dbContext.Player
                .FromSqlRaw("EXEC Chess.Player_Lookup @PlayerId = {0}", playerId)
                .ToListAsync();
                return player.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> PlayerSave(Player player)
        {
            try
            {
                await _dbContext.Player
                .FromSqlRaw("EXEC Chess.Player_Save @PlayerId = {0}, @PlayerTypeId = {1}, @Username = {2}, @PassHash = {3}, @Salt = {4}, @Email = {5}, @TotalRating = {6}, @DateCreatedAccount = {7}, @DateLastOnline = {8}, @Active = {9}",
                player.PlayerId, player.PlayerTypeId, player.Username, player.PassHash, player.Salt, player.Email, player.TotalRating, player.DateCreatedAccount, player.DateLastOnline, player.Active)
                .ToListAsync();
                return "Successfully saved player";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public async Task<string> PlayerDelete(int playerId)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync("EXEC Chess.Player_Delete @PlayerId = {0}", playerId);
                return "Successfully deleted player";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Player> PlayerLogin(string username)
        {
            var player = await _dbContext.Player
                .FromSqlRaw("EXEC Chess.Player_Login @Username = {0}", username)
                .ToListAsync();
                return player.SingleOrDefault();
        }
    }
}
