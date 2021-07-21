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
        private static object consoleLock = new object();
        static async Task Main(string[] args)
        {
            WriteLine("Enter websocket address, ex:  localhost:6868");
            var webSocketAddress = ReadLine();
            while (webSocketAddress.Length == 0)
            {
                WriteLine("Try again, this value must have a length > 0");
                WriteLine("Enter address, ex:   ");
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
                            WriteLine("getCortexInfo API was selected");
                            await Connect("wss://" + webSocketAddress, "getCortexInfo");
                            break;
                        case 2:
                            WriteLine("requestAccess API was selected");
                            await Connect("wss://" + webSocketAddress, "requestAccess");
                            break;
                        case 3:
                            WriteLine("queryHeadsets API was selected");
                            await Connect("wss://" + webSocketAddress, "queryHeadsets");
                            break;
                        case 4:
                            WriteLine("controlDevice API was selected");
                            await Connect("wss://" + webSocketAddress, "controlDevice");
                            break;
                        case 5:
                            WriteLine("authorize API was selected");
                            await Connect("wss://" + webSocketAddress, "authorize");
                            break;
                        case 6:
                            WriteLine("createSession API was selected");
                            await Connect("wss://" + webSocketAddress, "createSession");
                            break;
                        case 0:
                            WriteLine("Bye.");
                            keepGoing = false;
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
            WriteLine("Press any key to exit...");
            ReadKey();
        }
        private static int DisplayMenu()
        {
            WriteLine("1.  getCortexInfo");
            WriteLine("2.  requestAccess");
            WriteLine("3.  queryHeadsets");
            WriteLine("4.  controlDevice");
            WriteLine("5.  authorize");
            WriteLine("6.  createSession");
            WriteLine("0.  exit this app");
            WriteLine("Which method would you like to call?");
            var result = ReadLine();
            return ToInt32(result);
        }
        public static async Task Connect(string uri, string method)
        {            
            WriteLine($"Connecting to {uri} ...");

            ClientWebSocket webSocket = null;
            string json = "{\"method\":\"" + method + "\"}";

            switch (method)
            {
                case "getCortexInfo":
                    uri = uri + @"/" + method;
                    json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\"}";
                    break;
                case "requestAccess":
                    uri = uri + @"/" + method;
                    WriteLine("Enter Client Id:");
                    var requestAccessClientId = ReadLine();
                    WriteLine("Enter Client Secret:");
                    var requestAccessClientSecret = ReadLine();
                    json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\", " + 
                            "\"params\": { \"clientId\":\"" + requestAccessClientId + "\", \"clientSecret\":\"" + requestAccessClientSecret + "\"}}";
                    break;
                case "queryHeadsets":
                    uri = uri + @"/" + method;
                    WriteLine("Enter Headset Id:  ex: INSIGHT-5968369F (leave blank to search for all)");
                    var queryHeadsetsHeadsetId = ReadLine();
                    if (queryHeadsetsHeadsetId.Length > 0)
                    {
                        json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\", " +
                            "\"params\": { \"id\":\"" + queryHeadsetsHeadsetId + "\"}}";
                    }
                    else
                    {
                        json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\"}";
                    }                    
                    break;
                case "controlDevice":
                    uri = uri + @"/" + method;
                    WriteLine("Enter command:  ex: connect, disconnect, refresh");
                    var controlDeviceCommand = ReadLine();
                    if (controlDeviceCommand == "refresh")
                    {
                        json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\", " +
                            "\"params\": { \"command\":\"" + controlDeviceCommand + "\"}}";
                    }
                    else
                    {
                        WriteLine("Enter Headset Id:  ex: INSIGHT-5968369F");
                        var controlDeviceHeadsetId = ReadLine();
                        json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\", " +
                            "\"params\": { \"command\":\"" + controlDeviceCommand + "\", \"headset\":\"" + controlDeviceHeadsetId + "\"}}";
                    }                    
                    break;
                case "authorize":
                    uri = uri + @"/" + method;
                    WriteLine("Enter Client Id:");
                    var authorizeClientId = ReadLine();
                    WriteLine("Enter Client Secret:");
                    var authorizeClientSecret = ReadLine();
                    json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\", " +
                            "\"params\": { \"clientId\":\"" + authorizeClientId + "\", \"clientSecret\":\"" + authorizeClientSecret + "\"}}";
                    break;
                case "createSession":
                    WriteLine("Enter Headset Id:  ex: INSIGHT-5968369F");
                    var createSessionHeadsetId = ReadLine();
                    
                    //Need to get a connection via the 'controlDevice' API
                    json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"controlDevice\", " +
                            "\"params\": { \"command\":\"connect\", \"headset\":\"" + createSessionHeadsetId + "\"}}";
                    await GetConnectionAsync(uri + @"/controlDevice", json);

                    //Need to get a cortexToken via the 'authorize' API
                    WriteLine("Enter Client Id:");
                    var createSessionClientId = ReadLine();
                    WriteLine("Enter Client Secret:");
                    var createSessionClientSecret = ReadLine();
                    json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"authorize\", " +
                            "\"params\": { \"clientId\":\"" + createSessionClientId + "\", \"clientSecret\":\"" + createSessionClientSecret + "\"}}";
                    await GetTokenAsync(uri + @"/authorize", json);

                    WriteLine("Enter status:  ex: open, active");
                    var createSessionStatus = ReadLine();
                    //Get the token by cut\paste output of GetTokenAsync() from console window
                    WriteLine("Enter cortexToken: ");
                    var createSessionToken = ReadLine();
                    json = "{\"id\":\"1\", \"jsonrpc\":\"2.0\", \"method\":\"" + method + "\", " +
                            "\"params\": { \"cortexToken\":\"" + createSessionToken + "\", \"headset\":\"" + createSessionHeadsetId + "\", " +
                            "\"status\":\"" + createSessionStatus + "\"}}";
                    break;
                default:
                    throw new Exception($"{method} is not a valid method.  Bye.");
            }
            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                WriteLine($"The websocket connection is: {webSocket.State}");
                WriteLine();
                await Task.WhenAll(ReceiveAsync(webSocket), SendAsync(webSocket, json));
            }
            catch (WebSocketException wse)
            {
                WriteLine($"A WebSocketException happend: {wse.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"An Exception happend: {ex.Message}");
            }
            finally
            {
                if (webSocket != null) { webSocket.Dispose(); }
                WriteLine();

                lock (consoleLock)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("The webSocket connection is closed.");
                    ResetColor();
                    WriteLine();
                }
            }
        }
        private static async Task SendAsync(ClientWebSocket webSocket, string json)
        {
            var encoded = Encoding.UTF8.GetBytes(json);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Sending...");
            WriteLine(json);
            ResetColor();
            await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(json)), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        private static async Task ReceiveAsync(ClientWebSocket webSocket)
        {
            var buffer = new byte[1024];
            //var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //ForegroundColor = ConsoleColor.Green;
            //WriteLine("Receiving...");
            //WriteLine($"{Encoding.UTF8.GetString(buffer, 0, result.Count)}");
            //WriteLine($"result.MessageType is {result.MessageType.ToString()}");
            //ResetColor();

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Receiving...");
                WriteLine($"{Encoding.UTF8.GetString(buffer, 0, result.Count)}");
                ResetColor();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine($"Waiting...");
                Thread.Sleep(5000);
                ResetColor();
                //controlDevice - connect - the connection needs to loop through for a second message with a 104
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }

            //    //while (webSocket.State == WebSocketState.Open)
            //    //{
            //    //    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //    //    ForegroundColor = ConsoleColor.Green;
            //    //    WriteLine("Receiving...");
            //    //    WriteLine($"{Encoding.UTF8.GetString(buffer, 0, result.Count)}");
            //    //    ResetColor();
            //    //    if (wait)
            //    //    {
            //    //        ForegroundColor = ConsoleColor.Yellow;
            //    //        WriteLine("Waiting...");
            //    //        Thread.Sleep(5000);
            //    //        ResetColor();
            //    //        ForegroundColor = ConsoleColor.Red;
            //    //        WriteLine("Closing...");
            //    //        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            //    //        ResetColor();
            //    //        //wait = false;
            //    //    }

            //    //if (result.MessageType == WebSocketMessageType.Close)
            //    //{
            //    //    ForegroundColor = ConsoleColor.Red;
            //    //    WriteLine("Closing...");
            //    //    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            //    //    ResetColor();
            //    //}
            //    //else
            //    //{

            //    //}                    
            //    //}
            //}
        }
        private static async Task GetConnectionAsync(string uri, string json)
        {
            ClientWebSocket webSocket = null;
            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                var encoded = Encoding.UTF8.GetBytes(json);
                await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(json)), WebSocketMessageType.Text, true, CancellationToken.None);

                var buffer = new byte[1024];
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"{Encoding.UTF8.GetString(buffer, 0, result.Count)}");
                ResetColor();
            }
            catch (WebSocketException wse)
            {
                WriteLine($"A WebSocketException happend: {wse.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"An Exception happend: {ex.Message}");
            }
            finally
            {
                if (webSocket != null) { webSocket.Dispose(); }
                WriteLine();

                lock (consoleLock)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("The webSocket connection is closed.");
                    ResetColor();
                    WriteLine();
                }
            }
        }
        private static async Task GetTokenAsync(string uri, string json)
        {
            ClientWebSocket webSocket = null;
            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                var encoded = Encoding.UTF8.GetBytes(json);
                await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(json)), WebSocketMessageType.Text, true, CancellationToken.None);
                
                var buffer = new byte[1024];
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"{Encoding.UTF8.GetString(buffer, 0, result.Count)}");
                ResetColor();
            }
            catch (WebSocketException wse)
            {
                WriteLine($"A WebSocketException happend: {wse.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"An Exception happend: {ex.Message}");
            }
            finally
            {
                if (webSocket != null) { webSocket.Dispose(); }
                WriteLine();

                lock (consoleLock)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("The webSocket connection is closed.");
                    ResetColor();
                    WriteLine();
                }
            }
        }
    }
}
