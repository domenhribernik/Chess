using ChessProject.Repositories.Interfaces;
using ChessProject.Data
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

        public async Task<Player[]> PlayerList()
        {
            string json = await _playerRepository.PlayerList();
            return JsonConvert.DeserializeObject<Player[]>(json);
        }

        public async Task<string> PlayerSave(Player player)
        {
            return await _playerRepository.PlayerSave(player);
        }

        public async Task<string> PlayerDelete(int playerId)
        {
            return await _playerRepository.PlayerDelete(playerId);
        }

        public async Task<Player> PlayerLookup(int playerId)
        {
            return (Player) await _playerRepository.PlayerLookup(playerId);
        }

    }
}


