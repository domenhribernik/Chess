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
    public class GameChatRepository : Repository, IGameChatRepository
    {
        private ChessDbContext _dbContext;

        public GameChatRepository(ChessDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<GameChat>> GetGameChats(int gameId)
        {
            return await _dbContext.Chat
                .FromSqlRaw("EXEC Chess.ChatGame_List @GameId = {0}", gameId)
                .ToListAsync();
        }

        public async Task<string> ChatSave(GameChat chat)
        {
            try
            {
                await _dbContext.Chat
                .FromSqlRaw("EXEC Chess.Chat_Save @GameChatId = {0}, @GameId = {1}, @SendingPlayer = {2}, @Chat = {3}, @SendingTime = {4}",
                chat.GameChatId, chat.GameId, chat.SendingPlayer, chat.Chat, chat.SendingTime)
                .ToListAsync();
                return "Successfully saved player";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
