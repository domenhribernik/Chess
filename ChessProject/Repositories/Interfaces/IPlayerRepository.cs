using System.Linq;
using ChessProject.Data;

namespace ChessProject.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<string> PlayerList();
        Task<IEnumerable<Player>> PlayerLookup(int playerId);
        Task<string> PlayerSave(Player player);
        Task<string> PlayerDelete(int playerId);

    }
}
