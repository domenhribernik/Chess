﻿using System.Linq;
using ChessProject.Data;

namespace ChessProject.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
        Task<Player> PlayerLookup(int playerId);
        Task<string> PlayerSave(Player player);
        Task<string> PlayerDelete(int playerId);
        Task<Player> PlayerLogin(string username);
    }
}
