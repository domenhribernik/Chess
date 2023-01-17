using Microsoft.AspNetCore.SignalR;
using ChessProject.Data;
using ChessProject.PiecesData;

namespace ChessProject.Hubs
{
    public class MultiplayerHub : Hub
    {
        public async Task SendCoordinates(PieceData activePIece, int row, int column)
        {
            await Clients.All.SendAsync(Messages.receiveCoordinates, activePIece, row, column);
        }
    }
}
