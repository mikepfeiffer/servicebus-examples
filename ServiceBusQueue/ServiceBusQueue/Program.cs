using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusQueue
{
    class Program
    {
        private static string _conn = "Endpoint=sb://<namespace>.servicebus.windows.net/;SharedAccessKeyName=<Key Name>;SharedAccessKey=<Key>;EntityPath=<Queue Name>";
        private static QueueClient _client = QueueClient.CreateFromConnectionString(_conn);

        static void Main(string[] args)
        {
        }

        static void SendMessage(string msg)
        {
            var message = new BrokeredMessage(msg);
            _client.Send(message);
        }

        static void ReadMessage()
        {
            var options = new OnMessageOptions
            {
                AutoComplete = false
            };

            _client.OnMessage(m =>
            {
                var msg = m.GetBody<string>();

                if (msg == "Hello World!")
                {
                    Console.WriteLine(msg);
                    m.Complete();
                }

            }, options);
        }
    }
}
