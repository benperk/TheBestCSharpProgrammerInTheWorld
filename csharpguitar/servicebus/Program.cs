using System;
using System.Threading.Tasks;

using static System.Console;
using static System.Convert;

using Azure.Messaging.ServiceBus;

namespace AzureFunctionConsumerCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool keepGoing = true;
            try
            {
                do
                {
                    var selection = DisplayMenu();
                    switch (selection)
                    {
                        case 1:
                            WriteLine("You selected Event Hub.");
                            //MainEventHubAsync(args).GetAwaiter().GetResult();
                            break;
                        case 2:
                            WriteLine("You selected Storage Queue.");
                            //MainStorageQueueAsync(args).GetAwaiter().GetResult();
                            break;
                        case 3:
                            WriteLine("You selected Blob Storage.");
                            //MainBlobStorageAsync(args).GetAwaiter().GetResult();
                            break;
                        case 4:
                            WriteLine("You selected Service Bus.");
                            await MainServiceBusAsync(args);
                            break;
                        case 5:
                            WriteLine("You selected Cosomos DB.");
                            //MainCosmosDBAsync(args).GetAwaiter().GetResult();
                            break;
                        case 6:
                            WriteLine("You selected HTTP Trigger.");
                            //MainHTTPTriggerAsync(args).GetAwaiter().GetResult();
                            break;
                        case 7:
                            WriteLine("You selected Event Grid.");
                            WriteLine("NOT YET IMPLEMENTED.");
                            break;
                        case 8:
                            WriteLine("You selected Table Storage.");
                            //MainStorageTableAsync(args).GetAwaiter().GetResult();
                            break;
                        case 9:
                            WriteLine("You selected Microsoft Graph.");
                            WriteLine("You need to run this one from a browser and send your AAD credentials.");
                            break;
                        case 10:
                            WriteLine("You selected SendGrid.");
                            WriteLine("NOT YET IMPLEMENTED.");
                            break;
                        case 11:
                            WriteLine("You selected SignalR.");
                            WriteLine("NOT YET IMPLEMENTED.");
                            break;
                        case 12:
                            WriteLine("You selected Timer.");
                            WriteLine("This one is triggered with using a CRON schedule.");
                            break;
                        case 13:
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
                WriteLine($"Well...something happend that wasn't expected, specifically: {ex.Message}");
            }
        }
        static public int DisplayMenu()
        {
            WriteLine();
            WriteLine("1.  Event Hub");
            WriteLine("2.  Storage Queue");
            WriteLine("3.  Blob Storage");
            WriteLine("4.  Service Bus");
            WriteLine("5.  Cosomos DB");
            WriteLine("6.  HTTP Trigger");
            WriteLine("7.  Event Grid");
            WriteLine("8.  Table Storage");
            WriteLine("9.  Microsoft Graph");
            WriteLine("10. SendGrid");
            WriteLine("11. SignalR");
            WriteLine("12. Timer");
            WriteLine("13. Exit");
            WriteLine("Which would you like to trigger?  Enter '13' to exit.");
            var result = ReadLine();
            return ToInt32(result);
        }

        #region Service Bus
        private static async Task MainServiceBusAsync(string[] args)
        {
            WriteLine("Enter your Service Bus connection string:");
            var ServiceBusConnectionString = ReadLine();
            while (ServiceBusConnectionString.Length == 0)
            {
                WriteLine("Try again, this value must have a length > 0");
                WriteLine("Enter your Service Bus connection string:");
                ServiceBusConnectionString = ReadLine();
            }
            WriteLine("Send message(s) to a Queue or Topic?");
            var QueueOrTopic = ReadLine();
            while (QueueOrTopic.Length == 0)
            {
                WriteLine("Try again, enter either 'Queue' or 'Topic'");
                WriteLine("Enter your Queue name:");
                QueueOrTopic = ReadLine();
            }
            WriteLine("Enter your Queue/Topic name:");
            var QueueName = ReadLine();
            while (QueueName.Length == 0)
            {
                WriteLine("Try again, this value must have a length > 0");
                WriteLine("Enter your Queue/Topic name:");
                QueueName = ReadLine();
            }
            WriteLine("Send messages in 'batch' or 'single'?");
            var BatchOrSingle = ReadLine();
            while (BatchOrSingle.Length == 0)
            {
                WriteLine("Try again, this value must have a length > 0");
                WriteLine("'batch' messages together or send 'single', one by one:");
                BatchOrSingle = ReadLine();
            }
            WriteLine("Enter number of messages to add: ");
            int ServiceBusMessagesToSend = 0;
            while (!int.TryParse(ReadLine(), out ServiceBusMessagesToSend))
            {
                WriteLine("Try again, this value must be numeric.");
            }

            await using var client = new ServiceBusClient(ServiceBusConnectionString);
            ServiceBusSender sender = client.CreateSender(QueueName);

            await SendMessagesToServicebus(sender, QueueOrTopic.ToLower(), BatchOrSingle, ServiceBusMessagesToSend);
            await client.DisposeAsync();
        }
        private static async Task SendMessagesToServicebus(ServiceBusSender sender, string QueueOrTopic, string BatchOrSingle, int numMessagesToSend)
        {
            if (BatchOrSingle == "batch")
            {
                using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
                for (var i = 0; i < numMessagesToSend; i++)
                {
                    try
                    {
                        if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                        {
                            throw new Exception($"Failed to add message to the batch.");
                        }

                    }
                    catch (ServiceBusException sbe)
                    {
                        WriteLine($"ServiceBusException: {sbe.Message}");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{DateTime.Now} > Exception: {ex.Message}");
                    }
                }
                try
                {
                    await sender.SendMessagesAsync(messageBatch);
                }
                finally
                {
                    await sender.DisposeAsync();
                }
            }
            else if (BatchOrSingle == "single")
            {
                for (int i = 0; i < numMessagesToSend; i++)
                {
                    try
                    {
                        ServiceBusMessage message = new ServiceBusMessage($"Topic-Message-{i}-{Guid.NewGuid().ToString("N")}-{DateTime.Now.Minute}");
                        WriteLine($"Sending message: {message.Body}");
                        await sender.SendMessageAsync(message);
                    }
                    catch (ServiceBusException sbe)
                    {
                        WriteLine($"ServiceBusException: {sbe.Message}");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{DateTime.Now} > Exception: {ex.Message}");
                    }
                }
            }
            else
            {
                WriteLine($"0 messages sent. You entered {QueueOrTopic} instead of either 'Queue' or 'Topic'.");
            }
            WriteLine($"{numMessagesToSend} messages sent.");
        }
        #endregion
    }
}
