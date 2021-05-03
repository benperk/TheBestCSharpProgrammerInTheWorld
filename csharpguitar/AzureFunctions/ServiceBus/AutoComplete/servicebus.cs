using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace csharpguitar
{
    public static class servicebus
    {
        [FunctionName("sbfunction")]
        public static async Task Run([ServiceBusTrigger("complete", Connection = "SERVICE_BUS_CONNECTION")]Message message, ILogger log,
            MessageReceiver messageReceiver, string lockToken)
        {
            //this code will trigger an unhandled exception becuase it exists outside a try/catch
            //throw (new FunctionException("An unhandled FunctionException happened... goodbye..."));

            try
            {
                var Data = Encoding.UTF8.GetString(message.Body);
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {message.MessageId}");
                log.LogInformation($"The message is: {Data}");
                log.LogInformation($"SequenceNumber: {message.SystemProperties.SequenceNumber}");
                log.LogInformation($"DeliveryCount: {message.SystemProperties.DeliveryCount}");

                //Do whatever you need to do with the message

                //Code snippet that simulates transient issue 33% of the time
                Random r = new Random();
                var n = r.Next(1, 100);
                if (n % 3 == 0)
                {
                    throw (new TimeoutException("A transient exception happened, took longer than expected"));
                }
                //Code snippet to simulate a possible mailformed or invalid message
                if (n % 2 == 0)
                {
                    throw (new FormatException("The message failed to process, looks wrong..."));
                }
                //Code snippet that simulates a general exception another 20% of the time
                if (n % 5 == 0)
                {
                    throw (new Exception("An exception was thrown..."));
                }
                //If the code execution makes it here, then you are good to go
                await messageReceiver.CompleteAsync(lockToken);
            }
            catch (TimeoutException toex)
            {
                //Wait a couple of seconds
                //Let's assume the retry fails again, so we want abandon it
                //This will put the message back into the queue and increment DeliveryCount by 1
                //You also need to consider, when you will simply break out and stop totally
                log.LogInformation($"A transient exception happened: {toex.Message}");
                await messageReceiver.AbandonAsync(lockToken);
            }
            catch (FormatException fex)
            {
                if (message.SystemProperties.DeliveryCount > 2)
                {
                    log.LogInformation($"Sending message; {message.MessageId} to DLQ");
                    await messageReceiver.DeadLetterAsync(lockToken, fex.Message + " sending to DLQ");
                }
                else
                {
                    log.LogInformation($"An format exception happened: {fex.Message}, DeliveryCount: {message.SystemProperties.DeliveryCount}");
                    await messageReceiver.AbandonAsync(lockToken);
                }
            }
            catch (Exception ex)
            {
                log.LogInformation($"An exception happened: {ex.Message}, not sure why...");
                //Comment out this CompleteAsync and the messafe will get processed when Lock Duration is breached
                await messageReceiver.CompleteAsync(lockToken);
            }            
        }
    }
}
