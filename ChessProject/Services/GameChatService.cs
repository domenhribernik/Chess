using ChessProject.Data;
using ChessProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChessProject.Services
{
    public class GameChatService
    {
        private readonly IGameChatRepository _chatRepository;

        public GameChatService(IGameChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task<List<GameChat>> GetGameChats(int gameId)
        {
            return await _chatRepository.GetGameChats(gameId);
        }

        public async Task<string> ChatSave(GameChat chat)
        {
            return await _chatRepository.ChatSave(chat);
        }
    }
}
