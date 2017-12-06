using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusTopic
{
    class Program
    {
        private static string _conn = "Endpoint=sb://<namespace>.servicebus.windows.net/;SharedAccessKeyName=<policy name>;SharedAccessKey=<key>";
        private static string _topic = "<topic name>";
        
        static void Main(string[] args)
        {
        }

        static void SendMessage(string message)
        {
            var topicClient = TopicClient.CreateFromConnectionString(_conn, _topic);
            var msg = new BrokeredMessage(message);
            topicClient.Send(msg);
        }

        static void ReadMessage()
        {
            var subClient = SubscriptionClient.CreateFromConnectionString(_conn, _topic, "<subscription name>");
            subClient.OnMessage(m =>
            {
                Console.WriteLine(m.GetBody<string>());
            });
        }
    }
}
