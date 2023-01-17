using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChessProject.Data
{
    public class ChatClient
    {
        public const string HUBURL = "/ChatHub";
        private readonly NavigationManager _navigationManager;
        private HubConnection _hubConnection;

        private readonly string _username;
        private bool _started = false;
        public ChatClient(string username, NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _username = username;
        }

        public async Task StartAsync()
        {
            if (!_started)
            {
                _hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri(HUBURL)).Build();
                Console.WriteLine("Client: calling Start()");
                _hubConnection.On<string, string>(Messages.receive, (user, message) =>
                {
                    HandleReceiveMessage(user, message);
                });

                await _hubConnection.StartAsync();
                Console.WriteLine("ChatClient: Start returned");
                _started = true;
                await _hubConnection.SendAsync(Messages.register, _username);
            }
        }

        private void HandleReceiveMessage(string username, string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(username, message));
        }

        public event MessageReceivedEventHandler MessageReceived;
        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

        public async Task SendAsync(string message)
        {
            if (!_started)
            {
                throw new InvalidOperationException("Client not started");
            }
            await _hubConnection.SendAsync(Messages.send, _username, message);
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
            Console.WriteLine("ChatClient: Disposing");
            await StopAsync();
        }
    }

    public class MessageReceivedEventArgs : EventArgs
    {
        public string Username { get; set; }
        public string Message { get; set; }

        public MessageReceivedEventArgs(string username, string message)
        {
            Username = username;
            Message = message;
        }
    }
}
