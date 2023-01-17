using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using ChessProject.PiecesData;

namespace ChessProject.Data
{
    public class Multiplayer
    {
        public const string HUBURL = "/MultiplayerHub";
        private readonly NavigationManager _navigationManager;
        private HubConnection _hubConnection;
        private bool _started = false;

        public Multiplayer(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public async Task StartAsync()
        {
            if (!_started)
            {
                _hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri(HUBURL)).Build();
                Console.WriteLine("Multiplayer Client: calling Start()");
                _hubConnection.On<PieceData, int, int>(Messages.receiveCoordinates, (activePiece, row, column) =>
                {
                    HandleReceiveCoordinates(activePiece, row, column);
                });

                await _hubConnection.StartAsync();
                Console.WriteLine("Multiplayer: Start returned");
                _started = true;
            }
        }

        private void HandleReceiveCoordinates(PieceData activePiece, int row, int column)
        {
            CoordinatesReceived?.Invoke(this, new CoordinatesReceivedEventArgs(activePiece, row, column));
            Console.WriteLine("Event is hit.");
        }

        public event CoordinatesReceivedEventHandler CoordinatesReceived;
        public delegate void CoordinatesReceivedEventHandler(object sender, CoordinatesReceivedEventArgs e);

        public async Task SendAsyncCoordinates(PieceData activePiece, int row, int column)
        {
            if (!_started)
            {
                throw new InvalidOperationException("Multiplayer not started");
            }
            await _hubConnection.InvokeAsync(Messages.sendCoordinates, activePiece, row, column);
        }

        public async Task StopAsync()
        {
            if (_started)
            {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
                _started = false;
            }
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("MultiplayerClient: Disposing");
            await StopAsync();
        }
    }

    public class CoordinatesReceivedEventArgs : EventArgs
    {
        public PieceData ActivePiece { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public CoordinatesReceivedEventArgs(PieceData activePIece, int row, int column)
        {
            ActivePiece = activePIece;
            Row = row;
            Column = column;
        }
    }
}
