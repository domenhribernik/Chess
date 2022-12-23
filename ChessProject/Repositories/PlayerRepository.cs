using ChessProject.Services.Database;
using Microsoft.Extensions.Options;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;
using ChessProject.Data;
using System.Linq;

namespace ChessProject.Repositories
{
    public class PlayerRepository : Repository
    {
        public PlayerRepository(IOptions<ConnectionStrings> connectionString) : base(connectionString) { }

        public async Task<string> PlayerList(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("JSON", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

            await Database.ExecuteAsync("Chess.Player_List", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<string>("JSON");
        }

        public async Task<IEnumerable<Player>> PlayerLookup(int playerId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("PlayerId", playerId);

            return (IEnumerable<Player>)Database.QueryAsync<Player>("Chess.Player_Lookup", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<string> PlayerSave(Player player)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("PlayerId", player.PlayerId, DbType.Int32, ParameterDirection.InputOutput);
            parameters.Add("PlayerTypeId");
            parameters.Add("Username", player.Username);
            parameters.Add("Email", player.Email);
            parameters.Add("TotalRating", player.TotalRating);
            parameters.Add("DateCreatedAccount", player.DateCreatedAccount);
            parameters.Add("DateLastOnline", player.DateLastOnline);

            await Database.ExecuteAsync("Chess.Player_Save", parameters, commandType: CommandType.StoredProcedure);

            return "Successfully saved player";
        }

        public async Task<string> PlayerDelete(int playerId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("PlayerId", playerId);

            await Database.ExecuteAsync("Chess.Player_Delete", parameters, commandType: CommandType.StoredProcedure);

            return "Successfully deleted player";
        }
    }
}
