using ChessProject.Data;

namespace ChessProject.Repositories.Interfaces
{
    public interface IGameChatRepository
    {
        Task<List<GameChat>> GetGameChats(int gameId);
        Task<string> ChatSave(GameChat chat);
    }
}
