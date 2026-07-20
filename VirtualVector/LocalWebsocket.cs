using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace VirtualVector
{
    public static class LocalWebsocket
    {
        private static readonly ConcurrentDictionary<string, WebSocket> Clients = new();
        private static Boolean IsConnected = false;
        public static async Task Start()
        {
            if (!IsConnected)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:5000/");
                listener.Start();
                IsConnected = true;

                Console.WriteLine("Editor Router Started");

                while (true)
                {
                    var context = await listener.GetContextAsync();

                    if (!context.Request.IsWebSocketRequest)
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                        continue;
                    }

                    _ = Task.Run(() => HandleClient(context));
                }
            }
        }

        private static async Task HandleClient(HttpListenerContext context)
        {
            var socket = (await context.AcceptWebSocketAsync(null)).WebSocket;

            string clientName = "";

            byte[] buffer = new byte[1024 * 64];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(
                    new ArraySegment<byte>(buffer),
                    CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                    break;

                string json = Encoding.UTF8.GetString(buffer, 0, result.Count);

                //--------------------------------------------------
                // First message = Register
                //--------------------------------------------------

                if (json.StartsWith("REGISTER:"))
                {
                    clientName = json.Replace("REGISTER:", "");

                    Clients[clientName] = socket;

                    Console.WriteLine($"{clientName} Connected");

                    continue;
                }

                //--------------------------------------------------
                // Forward JSON exactly as received
                //--------------------------------------------------

                await Route(json);
            }

            if (clientName != "")
                Clients.TryRemove(clientName, out _);

            Console.WriteLine($"{clientName} Disconnected");
        }

        static async Task Route(string json)
        {
            //--------------------------------------------------
            // Extract target only
            //--------------------------------------------------

            int start = json.IndexOf("\"to\":\"");

            if (start == -1)
                return;

            start += 6;

            int end = json.IndexOf("\"", start);

            string target = json.Substring(start, end - start);

            //--------------------------------------------------
            // Broadcast
            //--------------------------------------------------

            if (target == "*")
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);

                foreach (var client in Clients.Values)
                {
                    if (client.State != WebSocketState.Open)
                        continue;

                    await client.SendAsync(
                        new ArraySegment<byte>(bytes),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }

                return;
            }

            //--------------------------------------------------
            // Send to one window
            //--------------------------------------------------

            if (Clients.TryGetValue(target, out var socket))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);

                await socket.SendAsync(
                    new ArraySegment<byte>(bytes),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            }
        }
    }
}