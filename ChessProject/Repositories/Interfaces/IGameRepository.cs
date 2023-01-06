using ChessProject.Data;

namespace ChessProject.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetGames();
        //Task<List<Game>> GetPlayerGames(int playerId);
        Task<Game> GameLookup(int gameId);
        Task<string> GameSave(Game game);
        //Task<string> GameDelete(int gameId);
    }
}
