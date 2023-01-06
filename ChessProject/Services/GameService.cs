using ChessProject.Data;
using ChessProject.Repositories;
using ChessProject.Repositories.Interfaces;

namespace ChessProject.Services
{
    public class GameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<Game>> GetGames()
        {
            return await _gameRepository.GetGames();
        }

        public async Task<string> GameSave(Game game)
        {
            return await _gameRepository.GameSave(game);
        }

        public async Task<Game> GameLookup(int gameId)
        {
            return await _gameRepository.GameLookup(gameId);
        }
    }
}
