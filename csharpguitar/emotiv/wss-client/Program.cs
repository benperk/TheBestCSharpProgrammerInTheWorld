using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static System.Console;
using static System.Convert;

namespace wss_client
{
    class Program
    {
        //https://github.com/paulbatum/WebSocket-Samples/blob/master/HttpListenerWebSocketEcho/Client/Client.cs
        //https://csharp.hotexamples.com/examples/-/ClientWebSocket/-/php-clientwebsocket-class-examples.html

        private static object consoleLock = new object();
        private const int receiveChunkSize = 8192;
        private const bool verbose = true;
        static async Task Main(string[] args)
        {
            Thread.Sleep(1000);
            WriteLine("Enter address, ex:  localhost:6868");
            var webSocketAddress = ReadLine();
            while (webSocketAddress.Length == 0)
            {
                WriteLine("Try again, this value must have a length > 0");
                WriteLine("Enter address, ex:  localhost:6868");
                webSocketAddress = ReadLine();
            }

            //https://emotiv.gitbook.io/cortex-api/connecting-to-the-cortex-api
            bool keepGoing = true;
            try
            {
                do
                {
                    var selection = DisplayMenu();
                    switch (selection)
                    {
                        case 1:
                            WriteLine("getCortexInfo");
                            await Connect("wss://" + webSocketAddress, "getCortexInfo");
                            break;
                        default:
                            throw new InvalidOperationException("You entered an invalid option.  Bye.");
                    }

                } while (keepGoing);
            }
            catch (Exception ex)
            {
                WriteLine($"An error happened: {ex.Message}");
            }

            //await Connect("wss://" + webSocketAddress);
            WriteLine("Press any key to exit...");
            ReadKey();
        }
        private static int DisplayMenu()
        {            
            WriteLine("1.  getCortexInfo");
            WriteLine("2.  ...");
            WriteLine("0. Exit");
            WriteLine("Which method would you like to call? Enter 0 to exit.");
            var result = ReadLine();
            return ToInt32(result);
        }
        public static async Task Connect(string uri, string method)
        {
            ClientWebSocket webSocket = null;
            //var json = "{\"method\":\"" + method + "\"}";
            var json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\"}";

            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                //await Task.WhenAll(Receive(webSocket), Send(webSocket));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
                WriteLine();

                lock (consoleLock)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("WebSocket closed.");
                    ResetColor();
                }
            }
        }
        private static async Task Send(ClientWebSocket webSocket, string json)
        {
            //https://stackoverflow.com/questions/24450109/how-to-send-receive-messages-through-a-web-socket-on-windows-phone-8-using-the-c
            var encoded = Encoding.UTF8.GetBytes(json);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length); 

            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

            //var random = new Random();
            //byte[] buffer = new byte[sendChunkSize];

            //while (webSocket.State == WebSocketState.Open)
            //{
            //    random.NextBytes(buffer);

            //    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
            //    LogStatus(false, buffer, buffer.Length);

            //    await Task.Delay(delay);
            //}
        }
        private static async Task Receive(ClientWebSocket webSocket)
        {
            //ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);
            //WebSocketReceiveResult result = null;

            //using (var ms = new MemoryStream())
            //{
            //    do
            //    {
            //        result = await ws.ReceiveAsync(buffer, CancellationToken.None);
            //        ms.Write(buffer.Array, buffer.Offset, result.Count);
            //    }
            //    while (!result.EndOfMessage);

            //    ms.Seek(0, SeekOrigin.Begin);

            //    using (var reader = new StreamReader(ms, Encoding.UTF8))
            //        return reader.ReadToEnd();
            //}

            byte[] buffer = new byte[receiveChunkSize];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    LogStatus(true, buffer, result.Count);
                }
            }
        }
        private static void LogStatus(bool receiving, byte[] buffer, int length)
        {
            lock (consoleLock)
            {
                ForegroundColor = receiving ? ConsoleColor.Green : ConsoleColor.Gray;
                WriteLine("{0} {1} bytes... ", receiving ? "Received" : "Sent", length);

                if (verbose)
                    WriteLine(BitConverter.ToString(buffer, 0, length));

                ResetColor();
            }
        }
    }
}
