using ChessProject.Repositories.Interfaces;
using ChessProject.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace ChessProject.Services
{
    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _playerRepository.GetPlayers();
        }

        public async Task<string> PlayerSave(Player player)
        {
            return await _playerRepository.PlayerSave(player);
        }

        public async Task<Player> PlayerLookup(int playerId)
        {
            return await _playerRepository.PlayerLookup(playerId);
        }

        public async Task<string> PlayerDelete(int playerId)
        {
            return await _playerRepository.PlayerDelete(playerId);
        }

        public async Task<Player> PlayerLogin(string username)
        {
            return await _playerRepository.PlayerLogin(username);
        }
    }
}


